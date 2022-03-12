namespace LifeInUK.Extractor.Options
{
    public class ExtractorOptions
    {
        public const string Selector = "ExtractorOptions";
        public RawDataPaths RawDataPath { get; set; }
        public string RawDataFileExtension { get; set; }
        public XPathOptions XPath { get; set; }
        public QuestionAttributes QuestionAttribute { get; set; }
    }
}