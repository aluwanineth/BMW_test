using System;
using System.Windows.Forms;

namespace BMWCompetencyTest.Helpers
{
    public static class FolderChooser
    {
        public static string BrowseDirectory()
        {
            string folderPath = string.Empty;
            try
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    folderPath = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return folderPath;
        }
    }
}
