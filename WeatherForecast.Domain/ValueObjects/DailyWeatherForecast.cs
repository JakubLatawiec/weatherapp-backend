using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.ValueObjects
{
    public class DailyWeatherForecast
    {
        public DateTime Date { get; private set; }
        public float MaxTemperature { get; private set; }
        public float MinTemperature { get; private set; }
        public int WeatherCode { get; private set; }
        public float SunshineTime { get; private set; }
        public float Pressure { get; private set; }
        public float SolarEnergy => CalculateSolarEnergy();

        public DailyWeatherForecast
            (
                DateTime date,
                float maxTemperature,
                float minTemperature,
                int weatherCode,
                float sunshineTime,
                float pressure
            )
        {
            Date = date;
            MaxTemperature = maxTemperature;
            MinTemperature = minTemperature;
            WeatherCode = weatherCode;
            SunshineTime = sunshineTime;
            Pressure = pressure;
        }

        private float CalculateSolarEnergy()
        {
            const float installationPower = 2.5F;
            const float panelEfficiency = 0.2F;
            float sunshineTimeInHours = SunshineTime / 3600;
            return installationPower * panelEfficiency * sunshineTimeInHours;
        }
    }
}
