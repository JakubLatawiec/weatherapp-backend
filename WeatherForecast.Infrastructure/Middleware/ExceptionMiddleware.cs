using Microsoft.AspNetCore.Http;
using WeatherForecast.Infrastructure.Adapters.OpenMeteo;
using WeatherForecast.Shared.Exceptions;

namespace WeatherForecast.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private async void SendExceptionResponse(HttpContext context, int statusCode, string message)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = System.Text.Json.JsonSerializer.Serialize(new
            {
                error = message,
                statusCode = statusCode
            });

            await context.Response.WriteAsync(response);
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (OpenMeteoException e)
            {
               SendExceptionResponse(context, e.StatusCode, e.Message);
            }
            catch (BadRequestException e)
            {
                SendExceptionResponse(context, e.StatusCode, e.Message);
            }
        }
    }
}
