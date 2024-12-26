using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.ValueObjects;

namespace WeatherForecast.Infrastructure.Adapters.OpenMeteo
{
    public static class OpenMeteoMapper
    {
        public static WeatherForecastData MapToEntities(OpenMeteoResponse response)
        {
            var forecasts = new List<DailyWeatherForecast>();
            for (int i = 0; i < response.Daily.Time.Count; ++i)
            {
                var startOfDay = response.Daily.Time[i];
                var endOfDay = startOfDay.AddDays(1);

                var dailyPressures = response.Hourly.Time
                    .Select((time, index) => new {Time = time, Pressure = response.Hourly.Pressure_msl[index]})
                    .Where(x => x.Time >= startOfDay && x.Time < endOfDay)
                    .Select(x => x.Pressure)
                    .ToList();

                var averagePressure = dailyPressures.Count != 0 ? dailyPressures.Average() : 0.0F;

                forecasts.Add(new DailyWeatherForecast(
                    date: response.Daily.Time[i],
                    maxTemperature: response.Daily.Temperature_2m_Max[i],
                    minTemperature: response.Daily.Temperature_2m_Min[i],
                    weatherCode: response.Daily.WeatherCode[i],
                    sunshineTime: response.Daily.Sunshine_Duration[i],
                    pressure: averagePressure
                ));
            }

            return new WeatherForecastData
            {
                Forecasts = forecasts
            };
        }
    }
}
