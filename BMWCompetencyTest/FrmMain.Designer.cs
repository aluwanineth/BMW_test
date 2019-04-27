namespace BMWCompetencyTest
{
    partial class FrmMain
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
            this.chkDontDelete = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReplicate = new System.Windows.Forms.Button();
            this.chkIncludeSubDir = new System.Windows.Forms.CheckBox();
            this.btnBrowseDestinationPath = new System.Windows.Forms.Button();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseSourcePath = new System.Windows.Forms.Button();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bWComparer = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // chkDontDelete
            // 
            this.chkDontDelete.AutoSize = true;
            this.chkDontDelete.Location = new System.Drawing.Point(286, 98);
            this.chkDontDelete.Name = "chkDontDelete";
            this.chkDontDelete.Size = new System.Drawing.Size(115, 21);
            this.chkDontDelete.TabIndex = 20;
            this.chkDontDelete.Text = "Do not delete";
            this.chkDontDelete.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(487, 217);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 29);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnViewLog
            // 
            this.btnViewLog.Location = new System.Drawing.Point(115, 217);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(114, 29);
            this.btnViewLog.TabIndex = 23;
            this.btnViewLog.Text = "&View Log";
            this.btnViewLog.UseVisualStyleBackColor = true;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(115, 167);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(447, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Progress Bar";
            // 
            // btnReplicate
            // 
            this.btnReplicate.Location = new System.Drawing.Point(115, 125);
            this.btnReplicate.Name = "btnReplicate";
            this.btnReplicate.Size = new System.Drawing.Size(84, 33);
            this.btnReplicate.TabIndex = 21;
            this.btnReplicate.Text = "&Replicate";
            this.btnReplicate.UseVisualStyleBackColor = true;
            this.btnReplicate.Click += new System.EventHandler(this.btnReplicate_Click);
            // 
            // chkIncludeSubDir
            // 
            this.chkIncludeSubDir.AutoSize = true;
            this.chkIncludeSubDir.Location = new System.Drawing.Point(115, 98);
            this.chkIncludeSubDir.Name = "chkIncludeSubDir";
            this.chkIncludeSubDir.Size = new System.Drawing.Size(165, 21);
            this.chkIncludeSubDir.TabIndex = 19;
            this.chkIncludeSubDir.Text = "Include Sub Directory";
            this.chkIncludeSubDir.UseVisualStyleBackColor = true;
            // 
            // btnBrowseDestinationPath
            // 
            this.btnBrowseDestinationPath.Location = new System.Drawing.Point(487, 56);
            this.btnBrowseDestinationPath.Name = "btnBrowseDestinationPath";
            this.btnBrowseDestinationPath.Size = new System.Drawing.Size(75, 31);
            this.btnBrowseDestinationPath.TabIndex = 18;
            this.btnBrowseDestinationPath.Text = "Browse";
            this.btnBrowseDestinationPath.UseVisualStyleBackColor = true;
            this.btnBrowseDestinationPath.Click += new System.EventHandler(this.btnBrowseDestinationPath_Click);
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.Location = new System.Drawing.Point(115, 60);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.ReadOnly = true;
            this.txtDestinationPath.Size = new System.Drawing.Size(366, 22);
            this.txtDestinationPath.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Destination";
            // 
            // btnBrowseSourcePath
            // 
            this.btnBrowseSourcePath.Location = new System.Drawing.Point(487, 20);
            this.btnBrowseSourcePath.Name = "btnBrowseSourcePath";
            this.btnBrowseSourcePath.Size = new System.Drawing.Size(75, 30);
            this.btnBrowseSourcePath.TabIndex = 15;
            this.btnBrowseSourcePath.Text = "Browse";
            this.btnBrowseSourcePath.UseVisualStyleBackColor = true;
            this.btnBrowseSourcePath.Click += new System.EventHandler(this.btnBrowseSourcePath_Click);
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(115, 23);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.ReadOnly = true;
            this.txtSourcePath.Size = new System.Drawing.Size(366, 22);
            this.txtSourcePath.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Source";
            // 
            // bWComparer
            // 
            this.bWComparer.WorkerReportsProgress = true;
            this.bWComparer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWComparer_DoWork);
            this.bWComparer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bWComparer_ProgressChanged);
            this.bWComparer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWComparer_RunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 261);
            this.Controls.Add(this.chkDontDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnViewLog);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReplicate);
            this.Controls.Add(this.chkIncludeSubDir);
            this.Controls.Add(this.btnBrowseDestinationPath);
            this.Controls.Add(this.txtDestinationPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseSourcePath);
            this.Controls.Add(this.txtSourcePath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replicate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDontDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReplicate;
        private System.Windows.Forms.CheckBox chkIncludeSubDir;
        private System.Windows.Forms.Button btnBrowseDestinationPath;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseSourcePath;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bWComparer;
    }
}

