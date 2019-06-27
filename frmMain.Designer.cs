namespace DownloadManager
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.prgDownload = new System.Windows.Forms.ProgressBar();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUrl.Location = new System.Drawing.Point(12, 9);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(83, 13);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "Download URL:";
            // 
            // txtUrl
            // 
            this.txtUrl.AllowDrop = true;
            this.txtUrl.Location = new System.Drawing.Point(101, 6);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(347, 20);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "http://www.dignaj.com/downloads/Memo.zip";
            this.txtUrl.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtUrl_DragDrop);
            this.txtUrl.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtUrl_DragEnter);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(193, 58);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(93, 23);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // prgDownload
            // 
            this.prgDownload.Location = new System.Drawing.Point(12, 118);
            this.prgDownload.Name = "prgDownload";
            this.prgDownload.Size = new System.Drawing.Size(436, 23);
            this.prgDownload.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgDownload.TabIndex = 3;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(101, 32);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(347, 20);
            this.txtPath.TabIndex = 4;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPath.Location = new System.Drawing.Point(12, 35);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(83, 13);
            this.lblPath.TabIndex = 5;
            this.lblPath.Text = "Download Path:";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(373, 58);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblProgress.Location = new System.Drawing.Point(13, 99);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(122, 16);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.Text = "Awaiting Download";
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Enabled = false;
            this.btnPauseResume.Location = new System.Drawing.Point(292, 58);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(75, 23);
            this.btnPauseResume.TabIndex = 9;
            this.btnPauseResume.Text = "Pause";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(463, 158);
            this.Controls.Add(this.btnPauseResume);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.prgDownload);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ProgressBar prgDownload;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnPauseResume;
    }
}

