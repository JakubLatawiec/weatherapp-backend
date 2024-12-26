using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Contracts.Dtos
{
    public class LocationDto
    {
        public string Country {  get; set; } = "Nowhere";
        public string City { get; set; } = string.Empty;
    }
}
