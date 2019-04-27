using BMWCompetencyTest.Dtos;
using System.Collections.Generic;

namespace BMWCompetencyTest.Contracts
{
    public interface IResults
    {
        List<CompareResult> SourceResults { get; set; }
        List<CompareResult> DestinationResults { get; set; }
    }
}
