using System;
using LifeInUK.Extractor.Documents;
using LifeInUK.Extractor.Mappers;
using LifeInUK.Extractor.Models.HtmlRawDataModels;
using LifeInUK.Extractor.Repositories;
using Microsoft.Extensions.Logging;

namespace LifeInUK.Extractor.Services
{
    public class QuestionSetService : IQuestionSetService
    {
        private readonly IRepository<QuestionSetDocument> _questionSetRepository;
        private readonly ILogger<QuestionSetService> _logger;

        public QuestionSetService(
            ILogger<QuestionSetService> logger,
            IRepository<QuestionSetDocument> questionSetRepository)
        {
            _questionSetRepository = questionSetRepository ?? throw new ArgumentNullException(nameof(questionSetRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Add(QuestionSet questionSet)
        {
            var existingQuestionSet = _questionSetRepository.FindOne(x =>
                 x.QuestionSetId == questionSet.Id ||
                 x.Title == questionSet.Title);

            if (existingQuestionSet != null)
            {
                _logger.LogWarning("QuestionSet {QuestionSetId} already exists with Id={ExistingQuestionSetId}: {QuestionSetTitle}",
                questionSet.Id,
                existingQuestionSet.QuestionSetId,
                existingQuestionSet.Title);
                return;
            }

            _questionSetRepository.InsertOne(questionSet.MapToQuestionSetDocument());
        }
    }
}