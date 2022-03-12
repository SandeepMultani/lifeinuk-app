using System.Collections.Generic;

namespace LifeInUK.Extractor.Entities
{
    public class QuestionSet : Entity
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public List<int> Questions { get; set; }
        public int TimeLimitInSeconds { get; set; }
    }
}