using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Domain.Interfaces.Repositories;
using WeatherForecast.Domain.Interfaces.Services;
using WeatherForecast.Infrastructure.Adapters.OpenMeteo;
using WeatherForecast.Infrastructure.Repositories;

namespace WeatherForecast.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient<IWeatherForecastService, OpenMeteoService>();
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            return services;
        }
    }
}
