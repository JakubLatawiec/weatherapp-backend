using MediatR;
using WeatherForecast.Application.Contracts.Dtos;
using WeatherForecast.Application.Contracts.Queries;
using WeatherForecast.Domain.Interfaces.Repositories;
using WeatherForecast.Shared.Exceptions;

namespace WeatherForecast.Application.Handlers
{
    public class WeeklyWeatherSummaryHandler : IRequestHandler<WeatherForecastSummaryQuery, WeatherForecastSummaryDto>
    {
        private readonly IWeatherForecastRepository _repository;

        public WeeklyWeatherSummaryHandler(IWeatherForecastRepository repository)
        {
            _repository = repository;
        }

        public async Task<WeatherForecastSummaryDto> Handle(WeatherForecastSummaryQuery request, CancellationToken cancellationToken)
        {
            if (request.latitude < -90 || request.latitude > 90)
                throw new BadRequestException("Latitude must be between -90 and 90 degrees.");

            if (request.longitude < -180 || request.longitude > 180)
                throw new BadRequestException("Longitude must be between -180 and 180 degrees.");

            var data = await _repository.GetWeatherForecastSummaryAsync(request.latitude, request.longitude);

            return new WeatherForecastSummaryDto
            {
                AveragePressure = data.AveragePressure,
                AverageSunshineTime = data.AverageSunshineTime,
                TemperatureMax = data.MaxTemperature,
                TemperatureMin = data.MinTemperature,
                WeekSummary = data.WeekDescription
            };
        }
    }
}
