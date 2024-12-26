using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Interfaces.Services;
using WeatherForecast.Domain.ValueObjects;

namespace WeatherForecast.Infrastructure.Adapters.OpenCage
{
    public class OpenCageService : ILocationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenCageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = Environment.GetEnvironmentVariable("OPENCAGE_API_KEY") ?? "";
        }

        public async Task<Location>? GetLocationFromCoordinatesAsync(double latitude, double longitude)
        {
            try
            {
                var url = $"https://api.opencagedata.com/geocode/v1/json" +
                     $"?q={latitude},{longitude}" +
                     $"&key={_apiKey}";

                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return null;

                var data = await response.Content.ReadFromJsonAsync<OpenCageResponse>();

                return data == null ? null : OpenCageMapper.MapToDomain(data);
            }
            catch
            {
                return null;
            }
        }
    }
}
