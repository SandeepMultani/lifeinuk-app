using System.Collections.Generic;

namespace LifeInUK.Extractor.Entities
{
    public class Question : Entity
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public List<QuestionOption> Options { get; set; }
        public QuestionMetadata Metadata { get; set; }
        public List<string> Errors { get; set; }
    }
}