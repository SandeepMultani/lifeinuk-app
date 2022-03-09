using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeInUK.Extractor.Extractors;
using LifeInUK.Extractor.Models;
using LifeInUK.Extractor.Parsers;

namespace LifeInUK.Extractor.Strategies
{
    public interface IExtractionStrategy<TContent, TContentSection>
    {
        IParser<TContent> Parser{get;}
        IExtractor<QuestionMetadata, TContentSection> QuestionMetadataExtractor { get; }
        IExtractor<Question, TContentSection> QuestionExtractor { get; }
        void Do(string content);
    }
}