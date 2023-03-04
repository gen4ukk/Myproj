using MyProj.Model;

namespace Myproj.Api
{
    public static class DB
    {
        private static readonly string[] Summaries = new[]
{
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public static IEnumerable<WeatherForecast> GetAll() 
        {
            
            var res =  Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return res;
        }

        public static WeatherForecast GetById(int id)
        {
            return GetAll().Where(x => x.Id == id).First();
        }
    }
}
