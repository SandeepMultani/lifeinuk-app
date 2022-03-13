using System.Collections.Generic;

namespace LifeInUK.Api.Models
{
    public class QuestionMetadata
    {
        public int Score { get; set; }
        public List<int> Answers { get; set; }
    }
}