using HotelProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5224/api/Staff");
            if (response.IsSuccessStatusCode)
            {
                var JsonData  = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Staff>>(JsonData);
                return View(values);
            }
            return View();
        }
    }
}
