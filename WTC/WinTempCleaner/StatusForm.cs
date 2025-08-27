using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTempCleaner.Core;
using WinTempCleaner.Utils;

namespace WinTempCleaner
{
    public partial class StatusForm : Form
    {
        private bool allowDeactivateClose = true;
        private int animationStep = 0;
        private bool isFadingIn = true;
        private const int animationMaxStep = 40;
        public StatusForm(Stats stats, DriveInfo driveInfo)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            PopulateData(stats, driveInfo);
        }

        private void PopulateData(Stats stats, DriveInfo driveInfo)
        {
            lblTimesCleaned.Text = stats.TimesCleaned.ToString();
            lblTotalFreed.Text = FormattingHelper.BytesToHumanReadableString(stats.TotalBytesFreed);

            long tempFolderSizeBytes = DriveMonitor.GetTempFolderSizeInBytes();
            lblTempSize.Text = FormattingHelper.BytesToHumanReadableString(tempFolderSizeBytes);

            if (driveInfo != null && driveInfo.IsReady)
            {
                long totalSize = driveInfo.TotalSize;
                long freeSpace = driveInfo.AvailableFreeSpace;
                long usedSpace = totalSize - freeSpace;
                double usedPercentage = (double)usedSpace / totalSize * 100.0;
                int progressValue = (int)Math.Round(usedPercentage);
                lblDriveUsage.Text = progressValue.ToString() + " %";
                long triggerFreeSpaceBytes = (totalSize * SystemThresholds.TRIGGER_PERCENTAGE) / 100;
                long spaceUntilTriggerBytes = freeSpace - triggerFreeSpaceBytes;
                if (spaceUntilTriggerBytes <= 0)
                {
                    lblCleanupThreshold.Text = "A cleanup is pending for the next startup.";
                }
                else
                {
                    string spaceUntilTriggerFormatted = FormattingHelper
                        .BytesToHumanReadableString(spaceUntilTriggerBytes);
                    lblCleanupThreshold.Text = $"Next cleanup will be triggered in " +
                        $"{spaceUntilTriggerFormatted}";
                }
            }
            else
            {
                lblDriveUsage.Text = "N/A";
                lblCleanupThreshold.Text = "N/A";
            }
        }

        private void StatusForm_Load(object sender, EventArgs e)
        {
            btnCleanNow.BackColor = Color.Black;
            animationTimer.Start();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (isFadingIn)
            {
                animationStep++;
            }
            else
            {
                animationStep--;
            }

            Color newColor = Color.FromArgb(animationStep, animationStep, animationStep);
            btnCleanNow.BackColor = newColor;

            if (animationStep >= animationMaxStep)
            {
                isFadingIn = false;
            }
            else if (animationStep <= 0)
            {
                isFadingIn = true;
            }
        }

        private void StatusForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            animationTimer.Stop();
            animationTimer.Dispose();
        }

        private void btnCleanNow_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();
            btnCleanNow.BackColor = Color.DarkGray;

            this.Cursor = Cursors.WaitCursor;
            btnCleanNow.Enabled = false;
            btnCleanNow.Text = "Cleaning...";

            Application.DoEvents();

            long bytesFreed = Cleaner.CleanUserTempFolder();
            Stats.RecordCleanup(bytesFreed);

            Stats updatedStats = Stats.Load();
            DriveInfo updatedDriveInfo = DriveMonitor.GetSystemDriveInfo();
            PopulateData(updatedStats, updatedDriveInfo);

            this.Cursor = Cursors.Default;
            btnCleanNow.Enabled = true;
            btnCleanNow.Text = "Initiate cleaning";

            allowDeactivateClose = false;

            string spaceFreedFormatted = FormattingHelper.BytesToHumanReadableString(bytesFreed);
            MessageBox.Show(
                $"Cleanup completed",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            allowDeactivateClose = true;

            btnCleanNow.BackColor = Color.Black;
            animationTimer.Start();
        }

        private void StatusForm_Deactivate(object sender, EventArgs e)
        {
            if (allowDeactivateClose)
            {
                this.Close();
            }
        }
    }
}
