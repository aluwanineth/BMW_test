using BMWCompetencyTest.Contracts;
using BMWCompetencyTest.Dtos;
using BMWCompetencyTest.Enums;
using BMWCompetencyTest.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BMWCompetencyTest.FoldersComparerRepository
{
    public class FoldersComparer : IFoldersComparer
    {
        readonly FrmMain _worker;
        public FoldersComparer(FrmMain worker)
        {
            _worker = worker;
        }
        public List<CompareResult> DestinationCompare(string destinationPath, string sourcePath)
        {
            List<CompareResult> _destinationResults = new List<CompareResult>();
            try
            {
                List<string> sourceFiles = FolderLister.GetAllFiles(sourcePath);
                List<string> destinationFiles = FolderLister.GetAllFiles(destinationPath);

                _worker.ReportProgress(45);

                foreach (string fileOrFolder in destinationFiles)
                {
                    if (fileOrFolder.IsFile())
                    {
                        CompareResult result = ProcessFile(fileOrFolder, sourceFiles, CompareDirection.DESTINATION);
                        if (IsNotPresent(result))
                            _destinationResults.Add(result);
                    }
                    else if (BaseInfo.IncludeSubDiretory)
                    {
                        List<CompareResult> results = ProcessFolder(fileOrFolder, sourceFiles, CompareDirection.DESTINATION);
                        _destinationResults.AddRange(GetDestinationOnly(results));
                    }
                }

                _worker.ReportProgress(65);
            }
            catch (Exception ex)
            {
                ProcessLog.logError(ex.Message);
            }
            return _destinationResults;
        }

        public List<CompareResult> SourceCompare(string sourcePath, string destinationPath)
        {
            List<CompareResult> _sourceResults = new List<CompareResult>();
            try
            {
                List<string> sourceFiles = FolderLister.GetAllFiles(sourcePath);
                List<string> destinationFiles = FolderLister.GetAllFiles(destinationPath);

                _worker.ReportProgress(15);

                foreach (string fileOrFolder in sourceFiles)
                {
                    if (fileOrFolder.IsFile())
                    {
                        _sourceResults.Add(ProcessFile(fileOrFolder, destinationFiles, CompareDirection.SOURCE));
                    }
                    else if (BaseInfo.IncludeSubDiretory)
                    {
                        _sourceResults.AddRange(ProcessFolder(fileOrFolder, destinationFiles, CompareDirection.SOURCE));
                    }
                }

                _worker.ReportProgress(30);
            }
            catch (Exception ex)
            {
                ProcessLog.logError(ex.Message);
            }
            return _sourceResults;
        }

        private List<CompareResult> ProcessFolder(string fileOrFolder, List<string> otherFiles, CompareDirection direction)
        {
            List<CompareResult> results = new List<CompareResult>();
            try
            {
                string dirName = '\\' + fileOrFolder.GetCurrentDir();
                string correspondingDir = otherFiles.SingleOrDefault(r => r.IsDirectory() && r.EndsWith(dirName));
                if (correspondingDir != null)
                {
                    List<string> sourceFiles = FolderLister.GetAllFiles(fileOrFolder);
                    List<string> destinationFiles = FolderLister.GetAllFiles(correspondingDir);

                    if (sourceFiles.Count == 0 && destinationFiles.Count == 0)
                    {
                        results.Add(ProcessEmptyDirectory(fileOrFolder, correspondingDir, direction));
                    }
                    else
                    {
                        foreach (string fileorFolder in destinationFiles)
                        {
                            results.AddRange(ProcessByType(fileorFolder, destinationFiles, direction));
                        }
                    }
                }
                else
                {
                    List<string> files = FolderLister.GetAllFiles(fileOrFolder);

                    if (files.Count > 0)
                    {
                        foreach (var file in files)
                        {
                            results.AddRange(ProcessByType(file, null, direction));
                        }
                    }
                    else
                    {
                        results.Add(ProcessEmptyDirectory(fileOrFolder, string.Empty, direction));
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessLog.logError(ex.Message);
            }

            return results;
        }
        private CompareResult ProcessEmptyDirectory(string currentFolder, string correspondingFolder, CompareDirection direction)
        {
            CompareResult result = new CompareResult
            {
                FileName = string.Empty,
                FileExtension = string.Empty
            };
            try
            {

                if (direction == CompareDirection.SOURCE)
                {
                    result.SourceFilePath = currentFolder;
                    result.DestinationFilePath = correspondingFolder;
                    result.SourceCreatedDate = currentFolder != string.Empty ? Directory.GetCreationTime(currentFolder) : DateTime.MinValue;
                    result.SourceModifiedDate = currentFolder != string.Empty ? Directory.GetLastWriteTime(currentFolder) : DateTime.MinValue;
                    result.DestinationCreatedDate = correspondingFolder != string.Empty ? Directory.GetCreationTime(correspondingFolder) : DateTime.MinValue;
                    result.DestinationModifiedDate = correspondingFolder != string.Empty ? Directory.GetLastWriteTime(correspondingFolder) : DateTime.MinValue;
                    result.ExistsSource = currentFolder != string.Empty;
                    result.ExistsDestination = correspondingFolder != string.Empty;
                }
                else
                {
                    result.DestinationFilePath = currentFolder;
                    result.SourceFilePath = correspondingFolder;
                    result.DestinationCreatedDate = currentFolder != string.Empty ? Directory.GetCreationTime(currentFolder) : DateTime.MinValue;
                    result.DestinationModifiedDate = currentFolder != string.Empty ? Directory.GetLastWriteTime(currentFolder) : DateTime.MinValue;
                    result.SourceCreatedDate = correspondingFolder != string.Empty ? Directory.GetCreationTime(correspondingFolder) : DateTime.MinValue;
                    result.SourceModifiedDate = correspondingFolder != string.Empty ? Directory.GetLastWriteTime(correspondingFolder) : DateTime.MinValue;
                    result.ExistsDestination = currentFolder != string.Empty;
                    result.ExistsSource = correspondingFolder != string.Empty;
                }

                result.Match = currentFolder != string.Empty && correspondingFolder != string.Empty;
                result.Compared = true;
            }
            catch (Exception ex)
            {
                ProcessLog.logError(ex.Message);
            }

            return result;
        }

        private CompareResult ProcessFile(string fileOrFolder, List<string> otherFiles, CompareDirection direction)
        {
            string file = otherFiles.SingleOrDefault(r => r.IsFile() && r.EndsWith('\\' + fileOrFolder.GetFileName()));
            CompareResult result = file != null ? ProcessFileInternal(fileOrFolder, file, direction)
                                                : ProcessFileInternal(fileOrFolder, string.Empty, direction);
            return result;
        }
        private CompareResult ProcessFileInternal(string fileOrFolder, string file, CompareDirection direction)
        {
            CompareResult result = new CompareResult
            {
                FileName = fileOrFolder.GetFileName(),
                FileExtension = fileOrFolder.GetFileExtension()
            };
            try
            {

                if (direction == CompareDirection.SOURCE)
                {
                    result.SourceFilePath = fileOrFolder;
                    result.SourceCreatedDate = File.GetCreationTime(fileOrFolder);
                    result.SourceModifiedDate = File.GetLastWriteTime(fileOrFolder);
                    result.SourceHash = file != string.Empty ? Helpers.MD5Hash.HashFile(fileOrFolder) : string.Empty;
                    result.DestinationFilePath = file != string.Empty ? file : string.Empty;
                    result.DestinationCreatedDate = file != string.Empty ? File.GetCreationTime(file) : DateTime.MinValue;
                    result.DestinationModifiedDate = file != string.Empty ? File.GetLastWriteTime(file) : DateTime.MinValue;
                    result.DestinationHash = file != string.Empty ? Helpers.MD5Hash.HashFile(file) : string.Empty;
                    result.ExistsSource = true;
                    result.ExistsDestination = file != string.Empty;
                }
                else
                {
                    result.DestinationFilePath = fileOrFolder;
                    result.DestinationCreatedDate = File.GetCreationTime(fileOrFolder);
                    result.DestinationModifiedDate = File.GetLastWriteTime(fileOrFolder);
                    result.DestinationHash = file != string.Empty ? MD5Hash.HashFile(fileOrFolder) : string.Empty;
                    result.SourceFilePath = file != string.Empty ? file : string.Empty;
                    result.SourceCreatedDate = file != string.Empty ? File.GetCreationTime(file) : DateTime.MinValue;
                    result.SourceModifiedDate = file != string.Empty ? File.GetLastWriteTime(file) : DateTime.MinValue;
                    result.SourceHash = file != string.Empty ? MD5Hash.HashFile(file) : string.Empty;
                    result.ExistsDestination = true;
                    result.ExistsSource = file != string.Empty;
                }

                result.Match = file != string.Empty ? result.SourceHash == result.DestinationHash : false;
                result.Compared = true;
                result.IsFile = true;
            }
            catch (Exception ex)
            {
                ProcessLog.logError(ex.Message);
            }
            return result;
        }
        private List<CompareResult> ProcessByType(string fileOrFolder, List<string> compareItems, CompareDirection direction)
        {
            List<string> _compareItems = compareItems ?? new List<string>();
            List<CompareResult> results = new List<CompareResult>();
            try
            {
                if (fileOrFolder.IsFile())
                {
                    results.Add(ProcessFile(fileOrFolder, _compareItems, direction));
                }
                else
                {
                    results.AddRange(ProcessFolder(fileOrFolder, _compareItems, direction));
                }
            }
            catch (Exception ex)
            {
                ProcessLog.logError(ex.Message);
            }
            return results;
        }
        private bool IsNotPresent(CompareResult result)
        {
            return !(result.ExistsSource && result.ExistsDestination);
        }

        private List<CompareResult> GetDestinationOnly(List<CompareResult> results)
        {
            return results.Where(i => i.ExistsSource != i.ExistsDestination).ToList();
        }
    }
}
