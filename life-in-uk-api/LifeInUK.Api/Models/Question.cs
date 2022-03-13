using System.Collections.Generic;

namespace LifeInUK.Api.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public List<QuestionOption> Options { get; set; }
        public QuestionMetadata Metadata { get; set; }
    }
}