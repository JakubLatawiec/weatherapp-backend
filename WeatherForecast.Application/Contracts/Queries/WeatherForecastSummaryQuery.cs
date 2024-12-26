using MediatR;
using WeatherForecast.Application.Contracts.Dtos;

namespace WeatherForecast.Application.Contracts.Queries
{
    public record WeatherForecastSummaryQuery(double latitude, double longitude) : IRequest<WeatherForecastSummaryDto>;
}
