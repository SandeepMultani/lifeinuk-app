using LifeInUK.Extractor.Extractors;
using LifeInUK.Extractor.Models.HtmlRawDataModels;
using LifeInUK.Extractor.Models;
using LifeInUK.Extractor.Parsers;

namespace LifeInUK.Extractor.Services
{
    public interface IExtractorService<TContent, TContentSection>
    {
        IParser<TContent> Parser { get; }
        IExtractor<QuestionMetadataCollection, TContentSection> QuestionMetadataExtractor { get; }
        IExtractor<Question, TContentSection> QuestionExtractor { get; }
        QuestionSet Extract(QuestionRawData rawData);
    }
}