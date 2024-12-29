using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Net;
using WeatherForecast.Api;

namespace WeatherForecast.Tests.UnitTests.Controllers
{
    public class WeatherForecastControllerUnitTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public WeatherForecastControllerUnitTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData(null, null, HttpStatusCode.BadRequest)]
        [InlineData(100.0, 0.0, HttpStatusCode.BadRequest)]
        [InlineData(0.0, 0.0, HttpStatusCode.OK)]
        public async Task GetDailyWeaherForecast(double? latitude, double? longitude, HttpStatusCode expectedStatusCode)
        {
            var query = $"/api/weatherforecast/daily?latitude={latitude}&longitude={longitude}";
            var response = await _client.GetAsync(query);
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }
    }
}
