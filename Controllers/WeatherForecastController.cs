using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeleniumExampleProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetWeatherFromMeteorology()
        {
            IWebDriver _webDriver = new ChromeDriver(@"C:\Users\orhan\source\repos\SeleniumExampleProject\SeleniumExampleProject\bin\Debug\netcoreapp3.1");
            _webDriver.Navigate().GoToUrl("https://www.mgm.gov.tr/");
            var data = _webDriver.FindElement(By.ClassName("pull-left")).FindElement(By.ClassName("ng-binding")).Text;
            _webDriver.Quit();
            return Ok(data);
        }
    }
}
