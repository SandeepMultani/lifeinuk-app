using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    public class XPathOptions
    {

        public string QuestionSetTitle { get; set; }
        public string QuestionMetadata { get; set; }
        public string Questions { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionTitleAlt { get; set; }
        public string QuestionOptions { get; set; }
        public string QuestionOptionItems { get; set; }
        public string QuestionOptionLabel { get; set; }
    }

    public class QuestionAttributes
    {
        public string QuestionIdAttribute { get; set; }
        public string QuestionTypeAttribute { get; set; }
        public string QuestionOptionPosition { get; set; }
    }

    public class RawDataPaths
    {
        public string ChapterBased { get; set; }
        public string PracticeTest { get; set; }
        public string MockExam { get; set; }
    }
}