using System.Collections.Generic;

namespace LifeInUK.Api.ValueSets
{
    public static class QuestionSetType
    {
        private static readonly Dictionary<string, string> questionSetTypes = new()
        {
            { ChapterBased, "Chapters" },
            { PracticeTest, "Practice Tests" },
            { MockExam, "Mock Exams" }
        };

        public const string ChapterBased = "chapter-based";
        public const string PracticeTest = "practice-test";
        public const string MockExam = "mock-exam";

        public static Dictionary<string, string> Types = questionSetTypes;
    }
}