using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("location")]
        public Task<GetWeatherByLocationQueryResponse> GetWeatherByLocation(GetWeatherByLocationParameters parameters)
        {
            return _mediator.Send(parameters);
        }
    }
}
