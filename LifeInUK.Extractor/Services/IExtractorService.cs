using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeInUK.Extractor.Parsers;
using LifeInUK.Extractor.Strategies;

namespace LifeInUK.Extractor.Services
{
    public interface IExtractorService<TContent, TContentSection>
    {
        IExtractionStrategy<TContent, TContentSection> ExtractionStrategy {get;}
        void Extract(string content);
    }
}