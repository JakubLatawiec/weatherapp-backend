using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Application.Contracts.Dtos;
using WeatherForecast.Application.Contracts.Queries;
using WeatherForecast.Domain.Interfaces.Repositories;
using WeatherForecast.Shared.Exceptions;

namespace WeatherForecast.Application.Handlers
{
    public class WeeklyWeatherForecastHandler : IRequestHandler<DailyWeatherForecastQuery, List<DailyWeatherForecastDto>>
    {
        private readonly IWeatherForecastRepository _repository;

        public WeeklyWeatherForecastHandler(IWeatherForecastRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DailyWeatherForecastDto>> Handle(DailyWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            if (request.latitude < -90 || request.latitude > 90)
                throw new BadRequestException("Latitude must be between -90 and 90 degrees.");

            if (request.longitude < -180 || request.longitude > 180)
                throw new BadRequestException("Longitude must be between -180 and 180 degrees.");


            var data = await _repository.GetDailyWeatherForecastAsync(request.latitude, request.longitude);
            List<DailyWeatherForecastDto> dtos = new List<DailyWeatherForecastDto>();

            foreach (var forecast in data.Forecasts)
            {
                dtos.Add(new DailyWeatherForecastDto
                {
                    Date = forecast.Date,
                    WeatherCode = forecast.WeatherCode,
                    TemperatureMin = forecast.MinTemperature,
                    TemperatureMax = forecast.MaxTemperature,
                    SolarEnergy = forecast.SolarEnergy
                });
            }

            return dtos;
        }
    }
}
