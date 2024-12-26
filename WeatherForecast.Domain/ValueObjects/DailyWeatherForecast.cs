using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Shared.Calculations;

namespace WeatherForecast.Domain.ValueObjects
{
    public class DailyWeatherForecast
    {
        public DateOnly Date { get; private set; }
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
            Date = DateOnly.FromDateTime(date);
            MaxTemperature = maxTemperature;
            MinTemperature = minTemperature;
            WeatherCode = weatherCode;
            SunshineTime = sunshineTime;
            Pressure = pressure;
        }

        private float CalculateSolarEnergy()
        {
            float sunshineTimeInHours = SunshineTime / 3600;   
            return MathF.Round(SolarCalculations.INSTALATION_POWER * SolarCalculations.PANEL_EFFICIENCY * sunshineTimeInHours, 2);
        }
    }
}
