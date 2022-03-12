using System;
using HtmlAgilityPack;
using LifeInUK.Extractor.Models;
using LifeInUK.Extractor.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LifeInUK.Extractor.Extractors.HtmlExtractors
{
    public class QuestionHtmlExtractor : IExtractor<Question, HtmlNode>
    {
        private readonly ILogger<QuestionHtmlExtractor> _logger;
        private readonly ExtractorOptions _extractorOptions;

        public QuestionHtmlExtractor(
            ILoggerFactory loggerFactory,
            IOptions<ExtractorOptions> extractorOptions)
        {
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));
            if (extractorOptions == null)
                throw new ArgumentNullException(nameof(extractorOptions));

            _logger = loggerFactory.CreateLogger<QuestionHtmlExtractor>();
            _extractorOptions = extractorOptions.Value;
        }

        public Question Extract(HtmlNode node)
        {
            var titleNode =
            node.SelectSingleNode(_extractorOptions.XPath.QuestionTitle) ??
            node.SelectSingleNode(_extractorOptions.XPath.QuestionTitleAlt);

            var questionOptions = node.SelectSingleNode(_extractorOptions.XPath.QuestionOptions);
            var question = new Question
            {
                Id = int.Parse(questionOptions.Attributes[_extractorOptions.QuestionAttribute.QuestionIdAttribute].Value),
                Title = titleNode.InnerText,
                Type = questionOptions.Attributes[_extractorOptions.QuestionAttribute.QuestionTypeAttribute].Value
            };

            var questionOptionsItems = questionOptions.SelectNodes(_extractorOptions.XPath.QuestionOptionItems);
            foreach (var op in questionOptionsItems)
            {
                var label = op
                            .SelectSingleNode(_extractorOptions.XPath.QuestionOptionLabel)
                            .InnerText
                            .Replace("\n", "")
                            .Trim();
                question.Options.Add(new QuestionOption
                {
                    Position = int.Parse(op.Attributes[_extractorOptions.QuestionAttribute.QuestionOptionPosition].Value),
                    Label = label
                });
            }
            return question;
        }
    }
}