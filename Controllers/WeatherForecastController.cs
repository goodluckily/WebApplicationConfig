using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApplicationConfig.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IOptionsMonitor<ConfigOptionsModel> _options;

        //IOptionsSnapshot
        //IOptionsMonitor (单例的时候拿到变更项)
        public WeatherForecastController(IOptionsMonitor<ConfigOptionsModel> options)
        {
            _options = options;

            _options.OnChange(option =>
            {
                Console.WriteLine($"change-->{option.key1}");
            });
        }

        [HttpGet]
        public string Get()
        {
            Console.WriteLine(_options.CurrentValue.key1);
            Console.WriteLine(_options.CurrentValue.key2);
            Console.WriteLine(_options.CurrentValue.key3);
            Console.WriteLine(_options.CurrentValue.key4);
            return "1";
        }
    }
}
