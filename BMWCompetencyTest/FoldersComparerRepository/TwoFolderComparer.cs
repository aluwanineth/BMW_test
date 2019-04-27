using BMWCompetencyTest.Contracts;
using BMWCompetencyTest.Dtos;

namespace BMWCompetencyTest.FoldersComparerRepository
{
    public class TwoFolderComparer : ITwoFolderComparer
    {
        private IFoldersComparer _comparer;

        private ComparisonResults _comparisonResults;

        public TwoFolderComparer(IFoldersComparer comparer) => _comparer = comparer;
        public ComparisonResults CompareDirectories()
        {
            _comparisonResults = new ComparisonResults
            {
                SourceResults = _comparer.SourceCompare(BaseInfo.SourcePath, BaseInfo.DestinationPath),
                DestinationResults = _comparer.DestinationCompare(BaseInfo.DestinationPath, BaseInfo.SourcePath)
            };
            return _comparisonResults;
        }
    }
}
