﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Contracts.Dtos
{
    public class WeatherForecastSummaryDto
    {
        public required LocationDto Location { get; set; }
        public required SummaryDto Summary { get; set; }
    }
}
