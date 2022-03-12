using LifeInUK.Extractor.Documents;
using LifeInUK.Extractor.Models.HtmlRawDataModels;

namespace LifeInUK.Extractor.Mappers
{
    public static class QuestionMappers
    {
        public static QuestionDocument MapToQuestionDocument(this Question question)
        {
            return new QuestionDocument
            {
                QuestionId = question.Id,
                Title = question.Title,
                Type = question.Type,
                Options = question.Options.ConvertAll(x => MapToOptionDocument(x)),
                Metadata = MapToMetadataDocument(question.Metadata),
                Errors = question.Errors,
                Hash = question.Hash
            };
        }

        private static QuestionOptionDocument MapToOptionDocument(this QuestionOption option)
        {
            return new QuestionOptionDocument
            {
                Position = option.Position,
                Label = option.Label,
                IsCorrect = option.IsCorrect
            };
        }

        private static QuestionMetadataDocument MapToMetadataDocument(this QuestionMetadata metadata)
        {
            return new QuestionMetadataDocument
            {
                Type = metadata.Type,
                QuestionId = metadata.Id,
                Score = metadata.Points,
                Answers = metadata.Correct
            };
        }
    }
}