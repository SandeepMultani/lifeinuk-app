using System.Collections.Generic;

namespace LifeInUK.Api.Models
{
    public class QuestionSetDetail : QuestionSet
    {
        public List<int> Questions { get; set; }
        public int TimeLimitInSeconds { get; set; }
    }
}