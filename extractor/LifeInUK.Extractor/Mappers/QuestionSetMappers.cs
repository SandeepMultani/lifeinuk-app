using LifeInUK.Extractor.Documents;
using LifeInUK.Extractor.Models.HtmlRawDataModels;

namespace LifeInUK.Extractor.Mappers
{
    public static class QuestionSetMappers
    {
        public static QuestionSetDocument MapToQuestionSetDocument(this QuestionSet questionSet)
        {
            return new QuestionSetDocument
            {
                QuestionSetId = questionSet.Id,
                Title = questionSet.Title,
                Type = questionSet.Type,
                Source = questionSet.Source,
                Questions = questionSet.QuestionIds,
                Position = questionSet.Position,
                TimeLimitInSeconds = questionSet.TimeLimitInSeconds
            };
        }
    }
}