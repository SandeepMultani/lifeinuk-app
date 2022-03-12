using System;
using HtmlAgilityPack;
using LifeInUK.Extractor.Services;
using Microsoft.Extensions.Logging;
namespace LifeInUK.Extractor
{
    public class Application
    {
        private readonly ILogger<Application> _logger;
        private readonly IRawDataService _rawDataService;
        private readonly IExtractorService<HtmlDocument, HtmlNode> _extractorService;

        public Application(
            ILogger<Application> logger,
            IRawDataService rawDataService,
            IExtractorService<HtmlDocument, HtmlNode> extractorService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _rawDataService = rawDataService ?? throw new ArgumentNullException(nameof(rawDataService));
            _extractorService = extractorService ?? throw new ArgumentNullException(nameof(extractorService));
        }

        public void Start(){
            foreach(var questionRawData in _rawDataService.Get()){
                _extractorService.Extract(questionRawData);
            }
        }
    }
}