﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Contracts.Dtos
{
    public class SummaryDto
    {
        public float AveragePressure { get; set; }
        public int AverageSunshineTime { get; set; }
        public float TemperatureMin { get; set; }
        public float TemperatureMax { get; set; }
        public string WeekSummary { get; set; } = string.Empty;
    }
}
