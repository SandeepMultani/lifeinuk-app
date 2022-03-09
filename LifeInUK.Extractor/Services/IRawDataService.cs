using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LifeInUK.Extractor.Services
{
    public interface IRawDataService
    {
        IEnumerable<string> Get();
    }
}