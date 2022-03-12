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
        private readonly IRepository<QuestionRedirectDocument> _questionRedirectRepository;

        public QuestionService(
            ILogger<QuestionService> logger,
            IRepository<QuestionDocument> questionRepository,
            IRepository<QuestionRedirectDocument> questionRedirectRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _questionRedirectRepository = questionRedirectRepository ?? throw new ArgumentNullException(nameof(questionRedirectRepository));
        }

        public void Add(Question question)
        {
            var existingQuestion = _questionRepository.FindOne(x =>
                x.QuestionId == question.Id ||
                x.Hash == question.Hash);

            if (existingQuestion != null)
            {
                _logger.LogWarning("Question {QuestionId} already exists with Id {ExistingQuestionId}: {QuestionTitle}",
                question.Id,
                existingQuestion.QuestionId,
                existingQuestion.Title);
                AddQuestionRedirect(question.Id, existingQuestion.QuestionId);
                return;
            }
            _questionRepository.InsertOne(question.MapToQuestionDocument());
        }

        private void AddQuestionRedirect(int questionId, int redirectedQuestionId)
        {
            if (questionId == redirectedQuestionId)
                return;

            var questionRedirect = new QuestionRedirectDocument
            {
                QuestionId = questionId,
                RedirectedToQuestionId = redirectedQuestionId
            };

            var existingQuestionRedirect = _questionRedirectRepository.FindOne(x =>
                x.QuestionId == questionRedirect.QuestionId &&
                x.RedirectedToQuestionId == questionRedirect.RedirectedToQuestionId);

            if (existingQuestionRedirect != null)
            {
                _logger.LogWarning("Question redirect with QuestionId {QuestionId} to RedirectedToQuestionId {RedirectedToQuestionId} already exists.",
                existingQuestionRedirect.QuestionId,
                existingQuestionRedirect.RedirectedToQuestionId);
                return;
            }

            _logger.LogInformation("Adding a question redirect with QuestionId {QuestionId} to RedirectedToQuestionId {RedirectedToQuestionId}",
                questionRedirect.QuestionId,
                questionRedirect.RedirectedToQuestionId);

            _questionRedirectRepository.InsertOne(questionRedirect);
        }
    }
}