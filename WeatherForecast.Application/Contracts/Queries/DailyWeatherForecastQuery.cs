using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Application.Contracts.Dtos;

namespace WeatherForecast.Application.Contracts.Queries
{
    public record DailyWeatherForecastQuery(double latitude, double longitude) : IRequest<DailyWeatherForecastDto>;
}
