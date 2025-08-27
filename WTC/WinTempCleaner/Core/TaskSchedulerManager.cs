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
        private const string AppName = "WinTempCleaner";
        private const string AutoStartTaskName = AppName + " AutoStart";
        private const string CleanupTaskName = AppName + " CleanupOnBoot";

        public static void SetAutoStart()
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Starts Win Temp Cleaner when the user logs on.";

                    td.Principal.RunLevel = TaskRunLevel.Highest;

                    td.Triggers.Add(new LogonTrigger());

                    string command = $"\"{Application.ExecutablePath}\"";
                    td.Actions.Add(new ExecAction(command, "/silent", null));

                    td.Settings.DisallowStartIfOnBatteries = false;
                    td.Settings.StopIfGoingOnBatteries = false;
                    td.Settings.ExecutionTimeLimit = TimeSpan.Zero;

                    ts.RootFolder.RegisterTaskDefinition(AutoStartTaskName, td);
                }
            }
            catch (Exception ex)
            {
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
                    if (ts.GetTask(CleanupTaskName) != null)
                    {
                        return;
                    }

                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Performs a one-time temp file cleanup on next boot.";
                    td.Principal.RunLevel = TaskRunLevel.Highest;

                    td.Triggers.Add(new BootTrigger());

                    string command = $"\"{Application.ExecutablePath}\"";
                    td.Actions.Add(new ExecAction(command, "/cleanup", null));

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
