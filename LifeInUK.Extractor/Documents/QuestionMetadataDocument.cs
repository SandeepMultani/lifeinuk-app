using System.Collections.Generic;

namespace LifeInUK.Extractor.Documents
{
    public class QuestionMetadataDocument
    {
        public string Type { get; set; }
        public int QuestionId { get; set; }
        public int Score { get; set; }
        public List<int> Answers { get; set; }
    }
}