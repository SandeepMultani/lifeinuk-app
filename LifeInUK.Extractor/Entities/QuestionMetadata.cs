using System.Collections.Generic;

namespace LifeInUK.Extractor.Entities
{
    public class QuestionMetadata : Entity
    {
        public string Type { get; set; }
        public int QuestionId { get; set; }
        public int Score { get; set; }
        public List<int> Answers { get; set; }
    }
}