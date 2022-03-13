using System.Collections.Generic;
using System.Threading.Tasks;
using LifeInUK.Api.Models;

namespace LifeInUK.Api.Services
{
    public interface IQuestionSetService
    {
        IDictionary<string,string> GetQuestionSetTypes();
        Task<IEnumerable<QuestionSet>> GetQuestionSets(string type);
        Task<QuestionSetDetail> GetQuestionSetDetail(string questionSetId);
    }
}