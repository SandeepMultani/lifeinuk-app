using System.Collections.Generic;
using LifeInUK.Api.Repositories.Mongo;

namespace LifeInUK.Api.Documents
{
    [BsonCollection("Questions")]
    public class QuestionDocument : Document
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public List<QuestionOptionDocument> Options { get; set; }
        public QuestionMetadataDocument Metadata { get; set; }
        public List<string> Errors { get; set; }
        public string Hash { get; set; }
    }
}