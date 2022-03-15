using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleAspNetApiDemo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleAspNetApiDemo.Controllers
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
        private readonly SchoolContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, SchoolContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = _context.Classes.Count(),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
