﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Shared.Exceptions
{
    public class BadRequestException : Exception
    {
        public int StatusCode { get; } = 400;
        public BadRequestException(string message) : base(message) { }
    }
}