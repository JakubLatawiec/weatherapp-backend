using WeatherForecast.Domain.Interfaces.Repositories;
using WeatherForecast.Domain.Interfaces.Services;
using WeatherForecast.Domain.ValueObjects;

namespace WeatherForecast.Infrastructure.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly IWeatherForecastService _weatherService;

        public WeatherForecastRepository(IWeatherForecastService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<WeatherForecastData> GetDailyWeatherForecastAsync(double latitude, double longitude)
        {
            var response = await _weatherService.GetWeatherForecastAsync(latitude, longitude);
            return response;
        }

        public async Task<WeatherForecastSummary> GetWeatherForecastSummaryAsync(double latitude, double longitude)
        {
            var response = await _weatherService.GetWeatherForecastAsync(latitude, longitude);
            return new WeatherForecastSummary(response);
        }
    }
}
