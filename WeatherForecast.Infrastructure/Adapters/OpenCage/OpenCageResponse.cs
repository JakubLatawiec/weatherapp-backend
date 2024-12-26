using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherForecast.Infrastructure.Adapters.OpenCage
{
    public class OpenCageResponse
    {
        [JsonPropertyName("results")]
        public required List<OpenCageResult> Results { get; set; }
    }

    public class OpenCageResult
    {
        [JsonPropertyName("components")]
        public required OpenCageComponents Components { get; set; }
    }

    public class OpenCageComponents
    {
        [JsonPropertyName("country")]
        public string? Country { get; set; }
        [JsonPropertyName("city")]
        public string? City { get; set; }
        [JsonPropertyName("state")]
        public string? State { get; set; }
        [JsonPropertyName("village")]
        public string? Village { get; set; }
    }
}
