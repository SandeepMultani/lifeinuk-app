using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using LifeInUK.Extractor.Options;
using LifeInUK.Extractor.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            if (rawDataService == null)
                throw new ArgumentNullException(nameof(rawDataService));

            if (extractorService == null)
                throw new ArgumentNullException(nameof(extractorService));

            _logger = logger;
            _rawDataService = rawDataService;
            _extractorService = extractorService;
        }

        public void Start(){
            _logger.LogInformation("Hello world from application.");
            foreach(var content in _rawDataService.Get()){
                _logger.LogInformation("file contents: {content}", content);
                _extractorService.Extract(content);
            }
        }
    }
}