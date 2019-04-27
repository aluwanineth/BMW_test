using BMWCompetencyTest.Contracts;
using System.Collections.Generic;

namespace BMWCompetencyTest.Dtos
{
    public class ComparisonResults : IResults
    {
        public List<CompareResult> SourceResults { get; set; }
        public List<CompareResult> DestinationResults { get; set; }
    }
}
