using HtmlAgilityPack;
using LifeInUK.Extractor.Models;
using Microsoft.Extensions.Logging;

namespace LifeInUK.Extractor.Extractors.HtmlExtractors
{
    public class QuestionMetadataHtmlExtractor : IExtractor<QuestionMetadata, HtmlNode>
    {
        private readonly ILogger<QuestionMetadataHtmlExtractor> _logger;
        public QuestionMetadataHtmlExtractor(ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
                throw new System.ArgumentNullException(nameof(loggerFactory));

            _logger = loggerFactory.CreateLogger<QuestionMetadataHtmlExtractor>();
        }

        public QuestionMetadata Extract(HtmlNode node)
        {
            _logger.LogInformation(nameof(QuestionMetadataHtmlExtractor));
            return new QuestionMetadata();
        }
    }
}