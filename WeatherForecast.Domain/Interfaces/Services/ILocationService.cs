using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.ValueObjects;

namespace WeatherForecast.Domain.Interfaces.Services
{
    public interface ILocationService
    {
        Task<Location>? GetLocationFromCoordinatesAsync(double latitude, double longitude);
    }
}
