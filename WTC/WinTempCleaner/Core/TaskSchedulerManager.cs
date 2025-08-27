using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTempCleaner.Core
{
    public static class TaskSchedulerManager
    {
        // A unique name for our tasks so we can find and update them later
        private const string AppName = "WinTempCleaner";
        private const string AutoStartTaskName = AppName + " AutoStart";
        private const string CleanupTaskName = AppName + " CleanupOnBoot";

        public static void SetAutoStart()
        {
            try
            {
                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    // Create a new task definition and assign properties
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Starts Win Temp Cleaner when the user logs on.";

                    // We want this to run with the highest privileges to avoid permission issues later
                    td.Principal.RunLevel = TaskRunLevel.Highest;

                    // Create a trigger that will fire when any user logs on
                    td.Triggers.Add(new LogonTrigger());

                    // Create an action that will launch the program with the "/silent" argument
                    string command = $"\"{Application.ExecutablePath}\"";
                    td.Actions.Add(new ExecAction(command, "/silent", null));

                    // Settings for the task
                    td.Settings.DisallowStartIfOnBatteries = false;
                    td.Settings.StopIfGoingOnBatteries = false;
                    td.Settings.ExecutionTimeLimit = TimeSpan.Zero; // Run indefinitely

                    // Register the task in the root folder.
                    // Using CreateOrUpdate means if the task already exists, it will be updated.
                    ts.RootFolder.RegisterTaskDefinition(AutoStartTaskName, td);
                }
            }
            catch (Exception ex)
            {
                // If this fails, it's not critical. We can show a message or log it.
                MessageBox.Show($"Could not set application to start with Windows.\nError: {ex.Message}",
                    "Setup Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void RemoveAutoStart()
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    if (ts.GetTask(AutoStartTaskName) != null)
                    {
                        ts.RootFolder.DeleteTask(AutoStartTaskName);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public static void ScheduleCleanupOnNextBoot()
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    // First, check if a cleanup task is already scheduled. If so, do nothing.
                    if (ts.GetTask(CleanupTaskName) != null)
                    {
                        return;
                    }

                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Performs a one-time temp file cleanup on next boot.";
                    td.Principal.RunLevel = TaskRunLevel.Highest;

                    // Create a trigger that will fire at startup (boot)
                    td.Triggers.Add(new BootTrigger());

                    // The action is to run the app with the "/cleanup" argument
                    string command = $"\"{Application.ExecutablePath}\"";
                    td.Actions.Add(new ExecAction(command, "/cleanup", null));

                    // IMPORTANT: This makes the task delete itself after it's finished.
                    td.Settings.DeleteExpiredTaskAfter = TimeSpan.Zero;

                    ts.RootFolder.RegisterTaskDefinition(CleanupTaskName, td);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not schedule the cleanup task.\nError: {ex.Message}",
                    "Scheduling Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
