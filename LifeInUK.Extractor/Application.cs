using System;
using HtmlAgilityPack;
using LifeInUK.Extractor.Models.HtmlRawDataModels;
using LifeInUK.Extractor.Services;
using Microsoft.Extensions.Logging;
namespace LifeInUK.Extractor
{
    public class Application
    {
        private readonly ILogger<Application> _logger;
        private readonly IRawDataService _rawDataService;
        private readonly IExtractorService<HtmlDocument, HtmlNode> _extractorService;
        private readonly IQuestionSetService _questionSetService;
        private readonly IQuestionService _questionService;

        public Application(
            ILogger<Application> logger,
            IRawDataService rawDataService,
            IExtractorService<HtmlDocument, HtmlNode> extractorService,
            IQuestionSetService questionSetService,
            IQuestionService questionService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _rawDataService = rawDataService ?? throw new ArgumentNullException(nameof(rawDataService));
            _extractorService = extractorService ?? throw new ArgumentNullException(nameof(extractorService));
            _questionSetService = questionSetService ?? throw new ArgumentNullException(nameof(questionSetService));
            _questionService = questionService ?? throw new ArgumentNullException(nameof(questionService));
        }

        public void Start()
        {
            foreach (var questionRawData in _rawDataService.Get())
            {
                _logger.LogInformation(questionRawData.Source);
                var questionSet = _extractorService.Extract(questionRawData);
                if (questionSet == null)
                    continue;

                Persist(questionSet);
            }
        }

        private void Persist(QuestionSet questionSet)
        {
            _questionSetService.Add(questionSet);
            foreach (var q in questionSet.Questions)
            {
                _questionService.Add(q);
            }
        }
    }
}