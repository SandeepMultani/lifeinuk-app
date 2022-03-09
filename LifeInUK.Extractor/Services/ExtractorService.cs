using System;
using HtmlAgilityPack;
using LifeInUK.Extractor.Options;
using LifeInUK.Extractor.Parsers;
using LifeInUK.Extractor.Strategies;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LifeInUK.Extractor.Services
{
    public class ExtractorService<TContent, TContentSection> : IExtractorService<TContent, TContentSection>
    {
        private readonly ILogger<ExtractorService<TContent, TContentSection>> _logger;
        private readonly ExtractorOptions _extractorOptions;

        public ExtractorService(
            ILoggerFactory loggerFactory,
            IOptions<ExtractorOptions> extractorOptions)
        {
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));

            if (extractorOptions == null || extractorOptions.Value == null)
                throw new ArgumentNullException(nameof(extractorOptions));

            _logger = loggerFactory.CreateLogger<ExtractorService<TContent, TContentSection>>();
            _extractorOptions = extractorOptions.Value;
            _extractionStrategy = (IExtractionStrategy<TContent, TContentSection>)new ExtractionFromHtmlStrategy(loggerFactory);
        }

        private readonly IExtractionStrategy<TContent, TContentSection> _extractionStrategy;
        public IExtractionStrategy<TContent, TContentSection> ExtractionStrategy {
            get {
                return _extractionStrategy;
            }
        }

        public void Extract(string content)
        {
            _logger.LogInformation(nameof(ExtractorService<TContent, TContentSection>));
            ExtractionStrategy.Do(content);
        }
    }
}