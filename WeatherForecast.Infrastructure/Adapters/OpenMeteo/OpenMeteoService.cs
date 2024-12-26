using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Interfaces.Services;
using WeatherForecast.Domain.ValueObjects;
using static System.Net.WebRequestMethods;

namespace WeatherForecast.Infrastructure.Adapters.OpenMeteo
{
    public class OpenMeteoService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public OpenMeteoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherForecastData> GetWeatherForecastAsync(double latitude, double longitude)
        {
            var url = string.Format(CultureInfo.InvariantCulture, "https://api.open-meteo.com/v1/forecast" +
                "?latitude={0}&longitude={1}" +
                "&daily=temperature_2m_max,temperature_2m_min,weathercode,sunshine_duration" +
                "&hourly=pressure_msl" +
                "&timezone=auto", latitude, longitude);

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new OpenMeteoException("Failed to fetch data from Open-Meteo API.", (int)response.StatusCode);

            var data = await response.Content.ReadFromJsonAsync<OpenMeteoResponse>();
            if (data == null)
                throw new OpenMeteoException("Failed to parse Open-Meteo API response", 500);

            var mappedData = OpenMeteoMapper.MapToEntities(data);
            if (mappedData == null)
                throw new OpenMeteoException("Failed to map Open-Meteo data", 500);

            return mappedData;
        }
    }
}
