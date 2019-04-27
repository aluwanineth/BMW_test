using BMWCompetencyTest.Contracts;
using BMWCompetencyTest.Dtos;
using BMWCompetencyTest.FoldersComparerRepository;
using BMWCompetencyTest.Helpers;
using System.IO;
using System.Threading;

namespace BMWCompetencyTest.Services
{
    public class ReplicateService
    {
        private readonly FrmMain _frmMain;
        public ReplicateService(FrmMain frmMain)
        {
            _frmMain = frmMain;
        }
        public void ReplicateFolder()
        {

            IFoldersComparer comparer = new FoldersComparer(_frmMain);
            ITwoFolderComparer twoFolderComparer = new TwoFolderComparer(comparer);
            IResults results = twoFolderComparer.CompareDirectories();

            foreach (var result in results.SourceResults)
            {
                if (result.Compared)
                {
                    if ((!result.Match) && (result.ExistsSource) && (result.ExistsDestination))
                    {
                        string logText = string.Format("{0} and {1} are different in size or date and time then it should be replaced", result.SourceFilePath, result.DestinationFilePath);
                        ProcessLog.logInfo(logText);
                        logText = string.Format("{0} will be replaced with {1}.", result.SourceFilePath, result.DestinationFilePath);
                        ProcessLog.logInfo(logText);
                        File.Replace(result.SourceFilePath, result.DestinationFilePath, null);
                        ProcessLog.logInfo("File replaced successfully");
                    }
                    
                    if ((!result.ExistsDestination) && (result.ExistsSource) && (result.IsFile))
                    {
                        string logText = string.Format("{0} exist in the destination folder it must be copied", result.SourceFilePath);
                        ProcessLog.logInfo(logText);
                        var destFile = result.SourceFilePath.Replace(BaseInfo.SourcePath, BaseInfo.DestinationPath);
                        System.IO.FileInfo newFile = new System.IO.FileInfo(destFile);
                        newFile.Directory.Create();
                        File.Copy(result.SourceFilePath, destFile, true);
                        ProcessLog.logInfo("File copied successfully");
                    }
                    
                    if ((!result.ExistsDestination) && (result.ExistsSource) && (!result.IsFile))
                    {
                        string logText = string.Format("{0} directory does not exist in the destination it must be created", result.SourceFilePath);
                        ProcessLog.logInfo(logText);
                        var destinationPath = result.SourceFilePath.Replace(BaseInfo.SourcePath, BaseInfo.DestinationPath);
                        if (!Directory.Exists(destinationPath))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(destinationPath);
                        }
                        ProcessLog.logInfo("directory created successfully");
                    }
                }
                _frmMain.ReportProgress(80);
            }

            foreach (var result in results.DestinationResults)
            {
                if (result.Compared)
                {
                    //If a file exists in the destination but not the source it must be deleted from the destination.
                    if ((!result.ExistsSource) && (result.ExistsDestination) && (result.IsFile))
                    {
                        if (!BaseInfo.DoNotDelete)
                        {
                            string logText = string.Format("{0} file exists in the destination but not the source it will be deleted from the destination", result.DestinationFilePath);
                            ProcessLog.logInfo(logText);
                            File.Delete(result.DestinationFilePath);
                            ProcessLog.logInfo("File deleted successfully");
                        }
                    }
                    //If a directory exists in the destination but not in the source it must be removed from the destination.
                    if ((!result.ExistsSource) && (result.ExistsDestination) && (!result.IsFile))
                    {
                        if (!BaseInfo.DoNotDelete)
                        {
                            string logText = string.Format("{0} directory exists in the destination but not in the source it must be removed from the destination", result.DestinationFilePath);
                            ProcessLog.logInfo(logText);
                            if (Directory.Exists(result.DestinationFilePath))
                            {
                                Directory.Delete(result.DestinationFilePath);
                                ProcessLog.logInfo("directory removed successfully");
                            }
                        }
                    }
                }
                _frmMain.ReportProgress(100);
            }
            _frmMain.ReportProgress(100);
            Thread.Sleep(1000);
        }
    }
}
  