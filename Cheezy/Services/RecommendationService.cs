using Cheezy.Database;
using Cheezy.Enums;
using Cheezy.Exceptions;
using Cheezy.Models;

namespace Cheezy.Services
{
    public class RecommendationService
    {
        private readonly ICheezyRepo _repo;
        private readonly ILogger<RecommendationService> _logger;
        public RecommendationService(ICheezyRepo cheezyRepo, ILogger<RecommendationService> logger)
        {
            _repo = cheezyRepo;
            _logger = logger;
        }

        public async Task<CheeseRecommendation> GetRecommendation(Taste taste)
        {
            var cheese = await _repo.GetRandomCheese(taste);
            if (cheese == null)
            {
                _logger.LogWarning("logging data not found exception from RecommendationService using Serilog");
                throw new RecommendationNotFoundException($"you like {taste} chesse ? There is nothing for you here. Nothing !");
            }

            return new CheeseRecommendation()
            {
                Text = $"Cheezy recommends: {cheese.Name}"
            };
        }
    }
}
