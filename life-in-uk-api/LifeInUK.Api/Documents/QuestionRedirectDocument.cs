using System.Collections.Generic;
using LifeInUK.Api.Repositories.Mongo;

namespace LifeInUK.Api.Documents
{
    [BsonCollection("QuestionRedirects")]
    public class QuestionRedirectDocument : Document
    {
        public int QuestionId { get; set; }
        public int RedirectedToQuestionId { get; set; }
    }
}