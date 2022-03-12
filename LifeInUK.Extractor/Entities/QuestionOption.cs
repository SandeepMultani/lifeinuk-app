namespace LifeInUK.Extractor.Entities
{
    public class QuestionOption : Entity
    {
        public int Position { get; set; }
        public string Label { get; set; }
        public bool IsCorrect { get; set; }
    }
}