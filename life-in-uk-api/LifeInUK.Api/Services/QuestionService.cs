using System.Threading.Tasks;
using AutoMapper;
using LifeInUK.Api.Documents;
using LifeInUK.Api.Models;
using LifeInUK.Api.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace LifeInUK.Api.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ILogger<QuestionService> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<QuestionDocument> _questionRepository;
        private readonly IRepository<QuestionRedirectDocument> _questionRedirectRepository;

        public QuestionService(
            ILogger<QuestionService> logger,
            IRepository<QuestionDocument> questionRepository,
            IRepository<QuestionRedirectDocument> questionRedirectRepository,
            IMapper mapper
        )
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _questionRedirectRepository = questionRedirectRepository ?? throw new ArgumentNullException(nameof(questionRedirectRepository));
        }

        public async Task<Question> GetQuestion(int questionId)
        {
            var question = await _questionRepository.FindOneAsync(x => x.QuestionId == questionId);
            if (question == null)
            {
                _logger.LogInformation("Question with id {QuestionId} not found. Checking redirect rules.", questionId);
                var redirect = await _questionRedirectRepository.FindOneAsync(x => x.QuestionId == questionId);
                if (redirect == null)
                {
                    _logger.LogError("Question with id {QuestionId} not found. Redirect rules not found.", questionId);
                    return null;
                }
                question = await _questionRepository.FindOneAsync(x => x.QuestionId == redirect.RedirectedToQuestionId);
                if (question == null)
                {
                    _logger.LogError("Question with id {QuestionId} not found. Redirect rule found but the alternative question with {RedirectedQuestionId} is not found.", questionId, redirect.RedirectedToQuestionId);
                    return null;
                }
            }
            return _mapper.Map<Question>(question);
        }
    }
}