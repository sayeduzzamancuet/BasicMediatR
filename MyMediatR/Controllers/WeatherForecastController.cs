using BasicMediatR;
using Microsoft.AspNetCore.Mvc;
using MyMediatR.Request.Greet;
using MyMediatR.Request.Print;

namespace MyMediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediatr mediatr;

        public WeatherForecastController(IMediatr mediatr, ILogger<WeatherForecastController> logger)
        {
            this.mediatr = mediatr;
            _logger = logger;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<bool> Get()
        {
            var request = new PrintToConsoleRequest
            {
                Text = "Hello from custom mediatr"
            };
            await mediatr.SendAsync(request);

            var greetCommand = new GreetCommand
            {
                Name = "Hello greet"
            };
            var result = await mediatr.SendAsync(greetCommand);
            return true;
        }
    }
}
