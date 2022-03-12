using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using LifeInUK.Extractor.Extensions;
using LifeInUK.Extractor.Models;
using Microsoft.Extensions.Logging;

namespace LifeInUK.Extractor.Extractors.HtmlExtractors
{
    public class QuestionMetadataHtmlExtractor : IExtractor<QuestionMetadataCollection, HtmlNode>
    {
        private readonly ILogger<QuestionMetadataHtmlExtractor> _logger;
        public QuestionMetadataHtmlExtractor(ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
                throw new System.ArgumentNullException(nameof(loggerFactory));

            _logger = loggerFactory.CreateLogger<QuestionMetadataHtmlExtractor>();
        }

        public QuestionMetadataCollection Extract(HtmlNode node)
        {
            var json = Regex.Match(node.InnerHtml.ReplaceWhitespace(""), @"json:(.+?)}}\);").Groups[1].Value;

            var quesMetadata = JsonSerializer.Deserialize<IDictionary<string, QuestionMetadata>>(json, 
                new JsonSerializerOptions{
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            return new QuestionMetadataCollection
            {
                Metadata = quesMetadata
            };
        }
    }
}