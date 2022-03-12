using System.Collections.Generic;
using LifeInUK.Extractor.Repositories.Mongo;

namespace LifeInUK.Extractor.Documents
{
    [BsonCollection("QuestionRedirects")]
    public class QuestionRedirect : Document
    {
        public int QuestionId { get; set; }
        public int RedirectedToQuestionId { get; set; }
    }
}