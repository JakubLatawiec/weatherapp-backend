using MediatR;
using WeatherForecast.Application.Contracts.Dtos;
using WeatherForecast.Application.Contracts.Queries;
using WeatherForecast.Domain.Interfaces.Repositories;
using WeatherForecast.Domain.Interfaces.Services;
using WeatherForecast.Shared.Exceptions;

namespace WeatherForecast.Application.Handlers
{
    public class WeatherForecastSummaryHandler : IRequestHandler<WeatherForecastSummaryQuery, WeatherForecastSummaryDto>
    {
        private readonly IWeatherForecastRepository _repository;
        private readonly ILocationService _locationService;

        public WeatherForecastSummaryHandler(IWeatherForecastRepository repository, ILocationService locationService)
        {
            _repository = repository;
            _locationService = locationService;
        }

        public async Task<WeatherForecastSummaryDto> Handle(WeatherForecastSummaryQuery request, CancellationToken cancellationToken)
        {
            if (request.latitude < -90 || request.latitude > 90)
                throw new BadRequestException("Latitude must be between -90 and 90 degrees.");

            if (request.longitude < -180 || request.longitude > 180)
                throw new BadRequestException("Longitude must be between -180 and 180 degrees.");

            var location = await _locationService.GetLocationFromCoordinatesAsync(request.latitude, request.longitude);
            var locationDto = new LocationDto
            {
                Country = location?.Country ?? "Nowhere",
                City = location?.City ?? string.Empty
            };

            var summaryData = await _repository.GetWeatherForecastSummaryAsync(request.latitude, request.longitude);
            var summaryDto = new SummaryDto
            {
                AveragePressure = summaryData.AveragePressure,
                AverageSunshineTime = summaryData.AverageSunshineTime,
                TemperatureMin = summaryData.MinTemperature,
                TemperatureMax = summaryData.MaxTemperature,
                WeekSummary = summaryData.WeekDescription
            };

            return new WeatherForecastSummaryDto
            {
                Location = locationDto,
                Summary = summaryDto
            };
        }
    }
}
