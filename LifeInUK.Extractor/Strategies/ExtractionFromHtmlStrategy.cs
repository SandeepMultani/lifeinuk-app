using System;
using HtmlAgilityPack;
using LifeInUK.Extractor.Extensions;
using LifeInUK.Extractor.Extractors;
using LifeInUK.Extractor.Extractors.HtmlExtractors;
using LifeInUK.Extractor.Models;
using LifeInUK.Extractor.Parsers;
using Microsoft.Extensions.Logging;

namespace LifeInUK.Extractor.Strategies
{
    public class ExtractionFromHtmlStrategy : IExtractionStrategy<HtmlDocument, HtmlNode>
    {
        private readonly ILogger<ExtractionFromHtmlStrategy> _logger;
        public ExtractionFromHtmlStrategy(ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));

            _logger = loggerFactory.CreateLogger<ExtractionFromHtmlStrategy>();

            _questionMetadataExtractor = new QuestionMetadataHtmlExtractor(loggerFactory);
            _questionExtractor = new QuestionHtmlExtractor(loggerFactory);
            _parser = new HtmlParser();
        }

        private readonly IParser<HtmlDocument> _parser;
        public IParser<HtmlDocument> Parser
        {
            get
            {
                return _parser;
            }
        }

        private readonly IExtractor<QuestionMetadata, HtmlNode> _questionMetadataExtractor;
        public IExtractor<QuestionMetadata, HtmlNode> QuestionMetadataExtractor
        {
            get
            {
                return _questionMetadataExtractor;
            }
        }

        private readonly IExtractor<Question, HtmlNode> _questionExtractor;
        public IExtractor<Question, HtmlNode> QuestionExtractor
        {
            get
            {
                return _questionExtractor;
            }
        }

        public void Do(string content)
        {
            _logger.LogInformation(nameof(ExtractionFromHtmlStrategy));
            var htmlDoc = Parser.Parse(content);

            QuestionMetadataExtractor.Extract(htmlDoc.GetNode("html"));
            QuestionExtractor.Extract(htmlDoc.GetNode("html"));
        }
    }
}