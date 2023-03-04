using Microsoft.AspNetCore.Mvc;
using MyProj.Model;

namespace Myproj.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return DB.GetAll();
        }

        [HttpGet("{id}")]
        public WeatherForecast GetById(int id)
        {
            return DB.GetById(id);
        }
    }
}