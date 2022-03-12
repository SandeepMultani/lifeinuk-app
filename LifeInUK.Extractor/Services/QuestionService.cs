using System;
using LifeInUK.Extractor.Documents;
using LifeInUK.Extractor.Mappers;
using LifeInUK.Extractor.Models.HtmlRawDataModels;
using LifeInUK.Extractor.Repositories;
using Microsoft.Extensions.Logging;

namespace LifeInUK.Extractor.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<QuestionDocument> _questionRepository;
        private readonly ILogger<QuestionService> _logger;

        public QuestionService(
            ILogger<QuestionService> logger,
            IRepository<QuestionDocument> questionRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Add(Question question)
        {
            var existingQuestion = _questionRepository.FindOne(x =>
                x.QuestionId == question.Id ||
                x.Hash == question.Hash);

            if (existingQuestion != null)
            {
                _logger.LogWarning("Question {QuestionId} already exists with Id={ExistingQuestionId}: {QuestionTitle}",
                question.Id,
                existingQuestion.QuestionId,
                existingQuestion.Title);
                return;
            }
            _questionRepository.InsertOne(question.MapToQuestionDocument());
        }
    }
}