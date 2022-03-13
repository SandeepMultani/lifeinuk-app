using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LifeInUK.Api.Documents;
using LifeInUK.Api.Models;
using LifeInUK.Api.Repositories;
using LifeInUK.Api.ValueSets;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace LifeInUK.Api.Services
{
    public class QuestionSetService : IQuestionSetService
    {
        private readonly ILogger<QuestionSetService> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<QuestionSetDocument> _questionSetRepository;

        public QuestionSetService(
            ILogger<QuestionSetService> logger,
            IRepository<QuestionSetDocument> questionSetRepository,
            IMapper mapper
        )
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            _questionSetRepository = questionSetRepository ?? throw new ArgumentNullException(nameof(questionSetRepository));
        }

        public async Task<QuestionSetDetail> GetQuestionSetDetail(string questionSetId)
        {
            var questionSet = await _questionSetRepository.FindOneAsync(x => x.QuestionSetId == questionSetId);
            if (questionSet == null)
            {
                _logger.LogError("A question set with id {QuestionSetId} not found", questionSetId);
                return (QuestionSetDetail)null;
            }
            return _mapper.Map<QuestionSetDetail>(questionSet);
        }

        public async Task<IEnumerable<QuestionSet>> GetQuestionSets(string type)
        {
            var questionSets = (await _questionSetRepository.FilterByAsync(x => x.Type == type)).OrderBy(x => x.Position);
            return _mapper.Map<IEnumerable<QuestionSet>>(questionSets);
        }

        public IDictionary<string, string> GetQuestionSetTypes()
        {
            return QuestionSetType.Types;
        }
    }
}