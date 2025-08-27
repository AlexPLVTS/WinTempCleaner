namespace WinTempCleaner
{
    partial class StatusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusForm));
            this.lebel111 = new System.Windows.Forms.Label();
            this.label222 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label333 = new System.Windows.Forms.Label();
            this.label444 = new System.Windows.Forms.Label();
            this.lblTimesCleaned = new System.Windows.Forms.Label();
            this.lblTotalFreed = new System.Windows.Forms.Label();
            this.lblTempSize = new System.Windows.Forms.Label();
            this.lblDriveUsage = new System.Windows.Forms.Label();
            this.lblCleanupThreshold = new System.Windows.Forms.Label();
            this.btnCleanNow = new System.Windows.Forms.Button();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lebel111
            // 
            this.lebel111.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lebel111.ForeColor = System.Drawing.Color.White;
            this.lebel111.Location = new System.Drawing.Point(37, 81);
            this.lebel111.Name = "lebel111";
            this.lebel111.Size = new System.Drawing.Size(281, 29);
            this.lebel111.TabIndex = 0;
            this.lebel111.Text = "Cleanups Performed:";
            // 
            // label222
            // 
            this.label222.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label222.ForeColor = System.Drawing.Color.White;
            this.label222.Location = new System.Drawing.Point(37, 125);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(257, 29);
            this.label222.TabIndex = 1;
            this.label222.Text = "Total Space Freed:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lifetime Statistics:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Status:";
            // 
            // label333
            // 
            this.label333.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label333.ForeColor = System.Drawing.Color.White;
            this.label333.Location = new System.Drawing.Point(37, 229);
            this.label333.Name = "label333";
            this.label333.Size = new System.Drawing.Size(236, 29);
            this.label333.TabIndex = 4;
            this.label333.Text = "Temp Folder Size:";
            // 
            // label444
            // 
            this.label444.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label444.ForeColor = System.Drawing.Color.White;
            this.label444.Location = new System.Drawing.Point(37, 270);
            this.label444.Name = "label444";
            this.label444.Size = new System.Drawing.Size(281, 29);
            this.label444.TabIndex = 6;
            this.label444.Text = "System Drive Usage:";
            // 
            // lblTimesCleaned
            // 
            this.lblTimesCleaned.AutoSize = true;
            this.lblTimesCleaned.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimesCleaned.ForeColor = System.Drawing.Color.White;
            this.lblTimesCleaned.Location = new System.Drawing.Point(327, 82);
            this.lblTimesCleaned.Name = "lblTimesCleaned";
            this.lblTimesCleaned.Size = new System.Drawing.Size(25, 28);
            this.lblTimesCleaned.TabIndex = 10;
            this.lblTimesCleaned.Text = "0";
            // 
            // lblTotalFreed
            // 
            this.lblTotalFreed.AutoSize = true;
            this.lblTotalFreed.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalFreed.ForeColor = System.Drawing.Color.White;
            this.lblTotalFreed.Location = new System.Drawing.Point(327, 126);
            this.lblTotalFreed.Name = "lblTotalFreed";
            this.lblTotalFreed.Size = new System.Drawing.Size(25, 28);
            this.lblTotalFreed.TabIndex = 11;
            this.lblTotalFreed.Text = "0";
            // 
            // lblTempSize
            // 
            this.lblTempSize.AutoSize = true;
            this.lblTempSize.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTempSize.ForeColor = System.Drawing.Color.White;
            this.lblTempSize.Location = new System.Drawing.Point(327, 230);
            this.lblTempSize.Name = "lblTempSize";
            this.lblTempSize.Size = new System.Drawing.Size(25, 28);
            this.lblTempSize.TabIndex = 12;
            this.lblTempSize.Text = "0";
            // 
            // lblDriveUsage
            // 
            this.lblDriveUsage.AutoSize = true;
            this.lblDriveUsage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDriveUsage.ForeColor = System.Drawing.Color.White;
            this.lblDriveUsage.Location = new System.Drawing.Point(327, 272);
            this.lblDriveUsage.Name = "lblDriveUsage";
            this.lblDriveUsage.Size = new System.Drawing.Size(25, 28);
            this.lblDriveUsage.TabIndex = 13;
            this.lblDriveUsage.Text = "0";
            // 
            // lblCleanupThreshold
            // 
            this.lblCleanupThreshold.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCleanupThreshold.ForeColor = System.Drawing.Color.White;
            this.lblCleanupThreshold.Location = new System.Drawing.Point(37, 313);
            this.lblCleanupThreshold.Name = "lblCleanupThreshold";
            this.lblCleanupThreshold.Size = new System.Drawing.Size(387, 71);
            this.lblCleanupThreshold.TabIndex = 14;
            this.lblCleanupThreshold.Text = "Cleanup schedulled";
            // 
            // btnCleanNow
            // 
            this.btnCleanNow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCleanNow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCleanNow.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCleanNow.ForeColor = System.Drawing.Color.White;
            this.btnCleanNow.Location = new System.Drawing.Point(97, 387);
            this.btnCleanNow.Name = "btnCleanNow";
            this.btnCleanNow.Size = new System.Drawing.Size(266, 37);
            this.btnCleanNow.TabIndex = 15;
            this.btnCleanNow.Text = "Initiate cleaning";
            this.btnCleanNow.UseVisualStyleBackColor = true;
            this.btnCleanNow.Click += new System.EventHandler(this.btnCleanNow_Click);
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 50;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblCleanupThreshold);
            this.panel1.Controls.Add(this.btnCleanNow);
            this.panel1.Controls.Add(this.lblDriveUsage);
            this.panel1.Controls.Add(this.lblTempSize);
            this.panel1.Controls.Add(this.lblTotalFreed);
            this.panel1.Controls.Add(this.lblTimesCleaned);
            this.panel1.Controls.Add(this.label444);
            this.panel1.Controls.Add(this.label333);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label222);
            this.panel1.Controls.Add(this.lebel111);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 457);
            this.panel1.TabIndex = 16;
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(454, 459);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatusForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Win Temp Cleaner - Status";
            this.Deactivate += new System.EventHandler(this.StatusForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatusForm_FormClosing);
            this.Load += new System.EventHandler(this.StatusForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lebel111;
        private System.Windows.Forms.Label label222;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label333;
        private System.Windows.Forms.Label label444;
        private System.Windows.Forms.Label lblTimesCleaned;
        private System.Windows.Forms.Label lblTotalFreed;
        private System.Windows.Forms.Label lblTempSize;
        private System.Windows.Forms.Label lblDriveUsage;
        private System.Windows.Forms.Label lblCleanupThreshold;
        private System.Windows.Forms.Button btnCleanNow;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Panel panel1;
    }
}