using System;
using System.Linq;
using System.Threading.Tasks;
using LifeInUK.Api.Models;

namespace LifeInUK.Api.Services
{
    public interface IQuestionService
    {
        Task<Question> GetQuestion(int questionId);
    }
}