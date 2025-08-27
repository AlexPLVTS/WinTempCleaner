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
            TaskSchedulerManager.SetAutoStart();
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
                TaskSchedulerManager.ScheduleCleanupOnNextBoot();
                cleanupHasBeenScheduled = true;

                notifyIcon2.ShowBalloonTip(5000,
                    "Win Temp Cleaner",
                    "Low disk space detected. A cleanup is scheduled for the next startup.",
                    ToolTipIcon.Info);
            }
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
            string url = "https://github.com/AlexPLVTS/WinTempCleaner?tab=readme-ov-file";

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
            string question = "Do you also want to prevent this application from starting with Windows?\n\n" +
                              "• Yes: Disable auto-start and exit.\n" +
                              "• No: Exit for this session only (will start again on reboot).\n" +
                              "• Cancel: Don't exit.";

            DialogResult result = MessageBox.Show(question, "Exit Options",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    // User wants to exit and disable
                    TaskSchedulerManager.RemoveAutoStart();
                    Application.Exit();
                    break;

                case DialogResult.No:
                    // User wants to exit for this session only
                    Application.Exit();
                    break;

                case DialogResult.Cancel:
                    // User changed their mind, do nothing
                    break;
            }
        }
    }
}
