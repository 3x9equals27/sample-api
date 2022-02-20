using Cheezy.Enums;
using Cheezy.Exceptions;
using Cheezy.Models;
using Cheezy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cheezy.Controllers
{
    [ApiController]
    [Route("cheezy")]
    public class CheezyController : ControllerBase
    {
        private readonly ILogger<CheezyController> _logger;
        private readonly RecommendationService _recommendations;

        public CheezyController(ILogger<CheezyController> logger, RecommendationService recommendationService)
        {
            _logger = logger;
            _recommendations = recommendationService;
        }

        [HttpGet("{taste}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CheeseRecommendation))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] Taste taste)
        {
            try
            {
                var cheeseRecommendation = await _recommendations.GetRecommendation(taste);

                return Ok(cheeseRecommendation);
            }
            catch (RecommendationNotFoundException rnf)
            {
                _logger.LogWarning("Someone must be looking for bitter cheese, logged from the COntroller");
                return NotFound(rnf.Message);
            }
            //WIP: instead of having this try catch block here, this is better of handled by a Middleware for known Exceptions
        }
    }
}
