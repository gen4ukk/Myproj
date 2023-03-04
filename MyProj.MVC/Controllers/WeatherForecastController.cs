using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProj.Model;
using Newtonsoft.Json;

namespace MyProj.MVC.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly HttpClient client;

        public WeatherForecastController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7007/"); // Замініть це на адресу вашого API
        }

        // GET: WeatherForecastController
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync("WeatherForecast"); // Замініть це на URL вашого API, який ви хочете викликати
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseBody);
            return View("WeatherForecast", res);
        }

        // GET: WeatherForecastController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeatherForecastController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeatherForecastController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeatherForecastController/Edit/5
        public async Task<ActionResult> Edit(WeatherForecast weatherForecast)
        {
            HttpResponseMessage response = await client.GetAsync($"WeatherForecast/{id}"); // Замініть це на URL вашого API, який ви хочете викликати
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<WeatherForecast>(responseBody);
            return View("Edit", res);
        }

        // POST: WeatherForecastController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeatherForecastController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeatherForecastController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
