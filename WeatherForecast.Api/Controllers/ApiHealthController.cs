using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiHealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetApiHealth()
        {
            return Ok("Api is working");
        }
    }
}
