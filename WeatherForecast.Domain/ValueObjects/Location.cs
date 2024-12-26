using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.ValueObjects
{
    public class Location
    {
        public string? Country { get; set; }
        public string? City { get; set; }
    }
}
