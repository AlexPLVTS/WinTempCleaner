using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTempCleaner.Core;

namespace WinTempCleaner
{
    static class Program
    {
        private const string AppMutexName = "WinTempCleaner-7EAB3E34-56F7-4A4B-9E3E-74C7A3A13E5A";
        private static Mutex appMutex;

        [STAThread]
        static void Main(string[] args)
        {
            bool createdNew;
            appMutex = new Mutex(true, AppMutexName, out createdNew);

            if (!createdNew)
            {
                return;
            }
            if (args.Contains("/cleanup"))
            {
                long bytesFreed = Cleaner.CleanUserTempFolder();
                Stats.RecordCleanup(bytesFreed);
                return;
            }
            if (!args.Contains("/silent"))
            {
                MessageBox.Show(
                    "Win Temp Cleaner will now run in the background and will start with Windows." +
                    "\n\nYou can access options by right-clicking its icon in the system tray.",
                    "Win Temp Cleaner Starting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            appMutex.ReleaseMutex();
        }
    }
}
