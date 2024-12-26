using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.ValueObjects;

namespace WeatherForecast.Infrastructure.Adapters.OpenCage
{
    public class OpenCageMapper
    {
        public static Location? MapToDomain(OpenCageResponse response)
        {
            var firstResult = response.Results.FirstOrDefault();
            if (firstResult == null || firstResult.Components == null)
                return null;

            var components = firstResult.Components;

            return new Location
            {
                Country = components.Country,
                City = components.City ?? components.Village ?? components.State
            };
        }
    }
}
