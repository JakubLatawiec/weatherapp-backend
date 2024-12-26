using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.ValueObjects
{
    public class WeatherForecastData
    {
        public List<DailyWeatherForecast>? Forecasts { get; set; }
    }
}
