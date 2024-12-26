namespace WeatherForecast.Domain.ValueObjects
{
    public class WeatherForecastSummary
    {
        public float MinTemperature { get; private set; }
        public float MaxTemperature { get; private set; }
        public float AveragePressure { get; private set; }
        public float AverageSunshineTime { get; private set; }
        public string WeekDescription { get; private set; } = string.Empty;

        public WeatherForecastSummary(WeatherForecastData weatherForecast)
        {
            MinTemperature = weatherForecast.Forecasts.Min(f => f.MinTemperature);
            MaxTemperature = weatherForecast.Forecasts.Max(f => f.MaxTemperature);
            AveragePressure = weatherForecast.Forecasts.Average(f => f.Pressure);
            AverageSunshineTime = weatherForecast.Forecasts.Average(f => f.SunshineTime);
            WeekDescription = calcWeekDescription(weatherForecast);
        }

        private string calcWeekDescription(WeatherForecastData weatherForecast)
        {
            var rainyDays = weatherForecast.Forecasts.Count(f => f.WeatherCode == 61 || f.WeatherCode == 63 || f.WeatherCode == 65);

            if (rainyDays >= 4)
                return "Rainy week";
            else
                return "Not rainy week";
        }
    }
}
