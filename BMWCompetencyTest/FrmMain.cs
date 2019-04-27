using BMWCompetencyTest.Dtos;
using BMWCompetencyTest.Helpers;
using BMWCompetencyTest.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMWCompetencyTest
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
       
        private void btnBrowseSourcePath_Click(object sender, EventArgs e)
        {
            txtSourcePath.Text = FolderChooser.BrowseDirectory();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ProcessLog.logInfo("loading user data");
            txtSourcePath.Text = Properties.Settings.Default.SourcePath;
            txtDestinationPath.Text = Properties.Settings.Default.DestinationPath;
            chkDontDelete.Checked = Properties.Settings.Default.DoNotDelete;
            chkIncludeSubDir.Checked = Properties.Settings.Default.IncludeSubDirectory;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessLog.logInfo("Saving user data");
            Properties.Settings.Default.SourcePath = txtSourcePath.Text;
            Properties.Settings.Default.DestinationPath = txtDestinationPath.Text ;
            Properties.Settings.Default.IncludeSubDirectory = chkIncludeSubDir.Checked;
            Properties.Settings.Default.DoNotDelete = chkDontDelete.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnBrowseDestinationPath_Click(object sender, EventArgs e)
        {
            txtDestinationPath.Text = FolderChooser.BrowseDirectory();
        }

        private string ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtSourcePath.Text))
                return "Please choose source folder";

            if (string.IsNullOrEmpty(txtDestinationPath.Text))
                return "Please choose destination folder";

            if (File.Exists(txtSourcePath.Text))
                return string.Format("{0} is a file, please choose a folder.", txtSourcePath.Text);

            if (File.Exists(txtDestinationPath.Text))
                return string.Format("{0} is a file, please choose a folder.", txtDestinationPath.Text);

            if (!Directory.Exists(txtSourcePath.Text))
                return string.Format("{0} does not exist", txtSourcePath.Text);

            if (!Directory.Exists(txtDestinationPath.Text))
                return string.Format("{0} does not exist", txtDestinationPath.Text);

            return string.Empty;
        }

        private void btnReplicate_Click(object sender, EventArgs e)
        {
            string status = ValidateInputs();

            if (status != string.Empty)
            {
                MessageBox.Show(status, "Folder Replicater");
                return;
            }
            BaseInfo.SourcePath = txtSourcePath.Text;
            BaseInfo.DestinationPath = txtDestinationPath.Text;
            BaseInfo.IncludeSubDiretory = chkIncludeSubDir.Checked;
            BaseInfo.DoNotDelete = chkDontDelete.Checked;

            bWComparer.RunWorkerAsync();
        }

        private void bWComparer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void bWComparer_DoWork(object sender, DoWorkEventArgs e)
        {
            ReplicateService replicate = new ReplicateService(this);
            replicate.ReplicateFolder();
        }
        public void ReportProgress(int percentage)
        {
            bWComparer.ReportProgress(percentage);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            Process.Start("logfile.log");
        }

        private void bWComparer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string status = "Process completed";
            ProcessLog.logInfo(status);
            MessageBox.Show(status, "Folder Replicater");
            return;
        }
    }
}
