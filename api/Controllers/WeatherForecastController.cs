using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("/model")]
        public IEnumerable<Model> Get()
        {
            return null;
        }
    }
}
