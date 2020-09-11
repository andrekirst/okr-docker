using System.Threading;
using System.Threading.Tasks;
using Api;
using Microsoft.AspNetCore.Mvc;
using UI.Logic;

namespace UI.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ISwaggerClientWrapper _swaggerClient;

        public WeatherController(ISwaggerClientWrapper swaggerClient)
        {
            _swaggerClient = swaggerClient;
        }

        [HttpPost]
        public async Task<IActionResult> Location(GetWeatherByLocationParameters parameters, CancellationToken cancellationToken = default)
        {
            var data = await _swaggerClient.GetLocation(parameters, cancellationToken);
            return View("Location", data);
        }
    }
}
