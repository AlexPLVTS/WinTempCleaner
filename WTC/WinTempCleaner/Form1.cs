using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTempCleaner.Core;
using WinTempCleaner.Utils;

namespace WinTempCleaner
{
    public partial class Form1 : Form
    {
        private bool cleanupHasBeenScheduled = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            RegistryManager.SetAutoStart();
            CheckAndSchedule();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckAndSchedule();
        }

        private void CheckAndSchedule()
        {
            long freeSpace = DriveMonitor.GetSystemDriveFreeSpacePercentage();

            if (freeSpace < SystemThresholds.TRIGGER_PERCENTAGE && freeSpace != -1 && !cleanupHasBeenScheduled)
            {
                RegistryManager.ScheduleCleanupOnNextBoot();
                cleanupHasBeenScheduled = true;

                notifyIcon2.ShowBalloonTip(5000,
                    "Win Temp Cleaner",
                    "Low disk space detected. A cleanup is scheduled for the next startup.",
                    ToolTipIcon.Info);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void statusStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stats currentStats = Stats.Load();
            DriveInfo systemDrive = DriveMonitor.GetSystemDriveInfo();

            using (StatusForm statusWindow = new StatusForm(currentStats, systemDrive))
            {
                statusWindow.ShowDialog();
            }
        }

        private void visitGitHubCheckForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/AlexPLVTS";

            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open the browser: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
