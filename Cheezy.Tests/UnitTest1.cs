using Autofac.Extras.Moq;
using Cheezy.Database;
using Cheezy.Database.Models;
using Cheezy.Enums;
using Cheezy.Exceptions;
using Cheezy.Services;
using Moq;
using Xunit;

namespace Cheezy.Tests
{
    public class UnitTest1
    {

        [Fact]
        public async void SugestionText_ProperForm()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ICheezyRepo>()
                    .Setup(x => x.GetRandomCheese(Taste.spicy))
                    .ReturnsAsync(new Cheese() { Name = "Le Gruyere" });
                var expectedRecommendationText = "Cheezy recommends: Le Gruyere";

                var cheeseRecommendationService = mock.Create<RecommendationService>();

                var recommendation = await cheeseRecommendationService.GetRecommendation(Taste.spicy);

                Assert.Equal(expectedRecommendationText, recommendation.Text);
            }
        }

        [Fact]
        public async void Exception_IsThrown()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ICheezyRepo>()
                    .Setup(x => x.GetRandomCheese(Taste.spicy))
                    .ReturnsAsync(() => null);

                var cheeseRecommendationService = mock.Create<RecommendationService>();

                var testCall = async () => await cheeseRecommendationService.GetRecommendation(Taste.spicy);
                await Assert.ThrowsAsync<RecommendationNotFoundException>(testCall);
            }
        }
    }
}