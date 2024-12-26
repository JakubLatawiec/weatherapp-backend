using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Contracts.Dtos
{
    public class DailyDto
    {
        public DateOnly Date { get; set; }
        public int WeatherCode { get; set; }
        public float TemperatureMin { get; set; }
        public float TemperatureMax { get; set; }
        public float SolarEnergy { get; set; }
    }
}
