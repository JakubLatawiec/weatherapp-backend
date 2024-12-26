using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Contracts.Dtos
{
    public class DailyWeatherForecastDto
    {
        public required LocationDto Location { get; set; }
        public required List<DailyDto> Daily {  get; set; }
    }
}
