using System;

namespace BMWCompetencyTest.Dtos
{
    public class CompareResult
    {
        public string SourceFilePath { get; set; }
        public string DestinationFilePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public DateTime SourceCreatedDate { get; set; }
        public DateTime SourceModifiedDate { get; set; }
        public DateTime DestinationCreatedDate { get; set; }
        public DateTime DestinationModifiedDate { get; set; }
        public bool ExistsSource { get; set; }
        public bool ExistsDestination { get; set; }
        public string SourceHash { get; set; }
        public string DestinationHash { get; set; }
        public bool Match { get; set; }
        public bool Compared { get; set; }
        public bool IsFile { get; set; }
    }
}
