using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeInUK.Extractor.Options
{
    public class ExtractorOptions
    {
        public const string Selector = "ExtractorOptions";
        public string RawDataPath { get; set; }
        public string RawDataFileExtension { get; set; }
        public XPathOptions XPath { get; set; }
    }

    public class XPathOptions
    {
        public string QuestionMetadata { get; set; }
        public string Questions { get; set; }
    }
}