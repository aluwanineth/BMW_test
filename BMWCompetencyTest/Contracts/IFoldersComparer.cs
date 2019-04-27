using BMWCompetencyTest.Dtos;
using System.Collections.Generic;

namespace BMWCompetencyTest.Contracts
{
    public interface IFoldersComparer
    {
        List<CompareResult> SourceCompare(string sourcePath, string destinationPath);
        List<CompareResult> DestinationCompare(string destinationPath, string sourcePath);
    }
}
