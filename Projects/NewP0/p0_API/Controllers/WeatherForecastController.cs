using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p0_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase //WeatherForecast inherits "Controller" functionality from the ControllerBase Class
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("TimeyWhimey/{firstName}/{lastName}")]
        public IActionResult MyDemoMethod(string firstName, string lastName)
        {
            return NotFound($"Congrats, {firstName} {lastName}, got to the new method!");
        }

        [HttpPut]
        [Route("postacustomer")]
        public IActionResult PostACustomer(Customer c)
        {
            if (ModelState.IsValid)//Check modelstate to make sure the model binding worked.
            {

            return Ok(c);
            }
            else
            {
                return Conflict(c);
            }
            //Customer c = new Customer()


        }
    }
}
