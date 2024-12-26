using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Infrastructure.Adapters.OpenMeteo
{
    public class OpenMeteoException : Exception
    {
        public int StatusCode { get; }
        public OpenMeteoException(string message, int statusCode) : base(message) 
        {
            StatusCode = statusCode; 
        }
    }
}
