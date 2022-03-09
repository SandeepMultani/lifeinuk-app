using HtmlAgilityPack;
using LifeInUK.Extractor.Models;
using Microsoft.Extensions.Logging;

namespace LifeInUK.Extractor.Extractors.HtmlExtractors
{
    public class QuestionHtmlExtractor : IExtractor<Question, HtmlNode>
    {
        private readonly ILogger<QuestionHtmlExtractor> _logger;
        public QuestionHtmlExtractor(ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
                throw new System.ArgumentNullException(nameof(loggerFactory));

            _logger = loggerFactory.CreateLogger<QuestionHtmlExtractor>();
        }

        public Question Extract(HtmlNode node)
        {
            _logger.LogInformation(nameof(QuestionHtmlExtractor));
            return new Question();
        }
    }
}