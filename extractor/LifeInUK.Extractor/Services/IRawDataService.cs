using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LifeInUK.Extractor.Models;

namespace LifeInUK.Extractor.Services
{
    public interface IRawDataService
    {
        IEnumerable<QuestionRawData> Get();
    }
}