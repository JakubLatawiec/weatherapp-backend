using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherForecast.Infrastructure.Adapters.OpenMeteo
{
    public class OpenMeteoResponse
    {
        [JsonPropertyName("daily")]
        public required DailyOpenMeteo Daily { get; set; }
        [JsonPropertyName("hourly")]
        public required HourlyOpenMeteo Hourly { get; set; }
    }
    public class DailyOpenMeteo
    {
        [JsonPropertyName("time")]
        public required List<DateTime> Time {  get; set; }
        [JsonPropertyName("temperature_2m_min")]
        public required List<float> Temperature_2m_Min { get; set; }
        [JsonPropertyName("temperature_2m_max")]
        public required List<float> Temperature_2m_Max { get; set; }
        [JsonPropertyName("weathercode")]
        public required List<int> WeatherCode { get; set; }
        [JsonPropertyName("sunshine_duration")]
        public required List<float> Sunshine_Duration { get; set; }
    }

    public class HourlyOpenMeteo
    {
        [JsonPropertyName("time")]
        public required List<DateTime> Time { get; set; }
        [JsonPropertyName("pressure_msl")]
        public required List<float> Pressure_msl { get; set; }
    }
}
