using CrossSolar.Controllers;
using CrossSolar.Models;
using CrossSolar.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CrossSolar.Tests.Controller
{
    public class AnalyticsControllerTest
    {
        public AnalyticsControllerTest()
        {
            _analyticsController = new AnalyticsController(_analyticsRepositoryMock.Object, _panelRepositoryMock.Object);
        }

        private readonly AnalyticsController _analyticsController;

        private readonly Mock<IAnalyticsRepository> _analyticsRepositoryMock = new Mock<IAnalyticsRepository>();
        private readonly Mock<IPanelRepository> _panelRepositoryMock = new Mock<IPanelRepository>();

        [Fact]
        public async Task GetAnalytics()
        {
            string panelId = "AAAA1111BBBB2222";

            var result = await _analyticsController.Get(panelId);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public async Task PostAnalytics()
        {
            string panelId = "AAAA1111BBBB2222";

            var oneHourElectricityModel = new OneHourElectricityModel()
            {
                Id = 0,
                DateTime = System.DateTime.Now,
                KiloWatt = 10000,
            };

            var result = await _analyticsController.Post(panelId, oneHourElectricityModel);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public async Task GetAnalyticsDayResults()
        {
            string panelId = "AAAA1111BBBB2222";

            var result = await _analyticsController.DayResults(panelId);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

    }
}
