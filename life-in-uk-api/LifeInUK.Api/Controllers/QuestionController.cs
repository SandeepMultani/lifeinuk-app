using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LifeInUK.Api.Models;
using LifeInUK.Api.Services;
using System.Threading.Tasks;

namespace LifeInUK.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IQuestionService _questionService;

        public QuestionController(
            ILogger<QuestionController> logger,
            IQuestionService questionService)
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            _questionService = questionService ?? throw new System.ArgumentNullException(nameof(questionService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await _questionService.GetQuestion(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }
    }
}
