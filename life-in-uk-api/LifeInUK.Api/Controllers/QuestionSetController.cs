using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LifeInUK.Api.Services;
using LifeInUK.Api.ValueSets;

namespace LifeInUK.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class QuestionSetController : ControllerBase
    {
        private readonly ILogger<QuestionSetController> _logger;
        private readonly IQuestionSetService _questionSetService;

        public QuestionSetController(
            ILogger<QuestionSetController> logger,
            IQuestionSetService questionSetService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _questionSetService = questionSetService ?? throw new ArgumentNullException(nameof(questionSetService));
        }

        [HttpGet("types")]
        public IActionResult GetTypes()
        {
            var types = _questionSetService.GetQuestionSetTypes();
            return Ok(types);
        }

        [HttpGet("types/{type}")]
        public async Task<IActionResult> GetQuestionSetsByType(string type)
        {
            var types = new string[]{
                QuestionSetType.ChapterBased,
                QuestionSetType.PracticeTest,
                QuestionSetType.MockExam
            };

            if (!types.Contains(type))
            {
                return BadRequest();
            }

            var questionSets = await _questionSetService.GetQuestionSets(type);
            return Ok(questionSets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionSet(string id)
        {
            var questionSet = await _questionSetService.GetQuestionSetDetail(id);
            if (questionSet == null)
            {
                return NotFound();
            }

            return Ok(questionSet);
        }
    }
}
