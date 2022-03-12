using System.Collections.Generic;

namespace LifeInUK.Extractor.Models.HtmlRawDataModels
{
    public class QuestionMetadata
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public int Points { get; set; }
        public List<int> Correct { get; set; }
    }
}