using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WeatherForecast.Application.Contracts.Queries;

namespace WeatherForecast.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeeklyForecast([FromQuery] double? latitude, [FromQuery] double? longitude)
        {
            if (!latitude.HasValue || !longitude.HasValue)
                return BadRequest(new { error = "Missing latitude or longitude values in request query." });

            /*
            if (!double.TryParse(latitude, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out var lat) ||
                !double.TryParse(longitude, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out var lng))
            {
                return BadRequest(new { error = "Latitude and longitude must be floating-point." });
            }
            */

            var result = await _mediator.Send(new DailyWeatherForecastQuery(latitude.Value, longitude.Value));
            return Ok(result);
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetWeatherSummary([FromQuery] double? latitude, [FromQuery] double? longitude)
        {
            if (!latitude.HasValue || !longitude.HasValue)
                return BadRequest(new { error = "Missing latitude or longitude values in request query." });

            var result = await _mediator.Send(new WeatherForecastSummaryQuery(latitude.Value, longitude.Value));
            return Ok(result);
        }
    }
}
