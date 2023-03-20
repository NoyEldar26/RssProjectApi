using Microsoft.AspNetCore.Mvc;

namespace RssProjectApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("rssData")]
        public async Task<ActionResult> rssData()
        {
            string Response;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://www.google.com/alerts/feeds/13583186640397089815/5906306061878099971"))
                {
                    Response = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response : ");
                    Console.WriteLine(Response);
                }
            }
            return Ok(Response);
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}