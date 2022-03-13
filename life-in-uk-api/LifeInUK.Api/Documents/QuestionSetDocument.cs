using System.Collections.Generic;
using LifeInUK.Api.Repositories.Mongo;

namespace LifeInUK.Api.Documents
{
    [BsonCollection("QuestionSets")]
    public class QuestionSetDocument : Document
    {
        public string QuestionSetId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public List<int> Questions { get; set; }
        public int TimeLimitInSeconds { get; set; }
        public decimal Position { get; set; }
    }
}