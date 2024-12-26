using WeatherForecast.Domain.ValueObjects;

namespace WeatherForecast.Domain.Interfaces.Repositories
{
    public interface IWeatherForecastRepository
    {
        Task<WeatherForecastData> GetDailyWeatherForecastAsync(double latitude, double longitude);
        Task<WeatherForecastSummary> GetWeatherForecastSummaryAsync(double latitude, double longitude);
    }
}
