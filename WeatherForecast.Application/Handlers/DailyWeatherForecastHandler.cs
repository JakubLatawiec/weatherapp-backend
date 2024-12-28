using MediatR;
using WeatherForecast.Application.Contracts.Dtos;
using WeatherForecast.Application.Contracts.Queries;
using WeatherForecast.Domain.Interfaces.Repositories;
using WeatherForecast.Domain.Interfaces.Services;
using WeatherForecast.Shared.Exceptions;

namespace WeatherForecast.Application.Handlers
{
    public class DailyWeatherForecastHandler : IRequestHandler<DailyWeatherForecastQuery, DailyWeatherForecastDto>
    {
        private readonly IWeatherForecastRepository _repository;
        private readonly ILocationService _locationService;

        public DailyWeatherForecastHandler(IWeatherForecastRepository repository, ILocationService locationService)
        {
            _repository = repository;
            _locationService = locationService;
        }

        public async Task<DailyWeatherForecastDto> Handle(DailyWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            if (request.latitude < -90 || request.latitude > 90)
                throw new BadRequestException("Latitude must be between -90 and 90 degrees.");

            if (request.longitude < -180 || request.longitude > 180)
                throw new BadRequestException("Longitude must be between -180 and 180 degrees.");
            

            var location = await _locationService.GetLocationFromCoordinatesAsync(request.latitude, request.longitude);
            var locationDto = new LocationDto
            {
                Country = location?.Country ?? "Nowhere",
                City = location?.City ?? "Middle of"
            };

            var dailyWeather = await _repository.GetDailyWeatherForecastAsync(request.latitude, request.longitude);

            var dailyDtos = dailyWeather.Forecasts.Select(forecast => new DailyDto
            {
                Date = forecast.Date,
                WeatherCode = forecast.WeatherCode,
                TemperatureMin = forecast.MinTemperature,
                TemperatureMax = forecast.MaxTemperature,
                SolarEnergy = forecast.SolarEnergy
            }).ToList();

            return new DailyWeatherForecastDto
            {
                Location = locationDto,
                Daily = dailyDtos
            };
        }
    }
}
