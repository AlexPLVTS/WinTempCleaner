using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTempCleaner.Core
{
    public static class RegistryManager
    {
        private const string RunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        private const string RunOnceKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce";

        private const string AppName = "WinTempCleanerService";

        public static void SetAutoStart()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKey, true);
            // This command ensures that when Windows starts our app, it does so silently.
            string command = $"\"{Application.ExecutablePath}\" /silent";
            key.SetValue(AppName, command);
            key.Close();
        }

        public static void ScheduleCleanupOnNextBoot()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RunOnceKey, true);
            string command = $"\"{Application.ExecutablePath}\" /cleanup";
            key.SetValue(AppName, command);
            key.Close();
        }
    }
}
