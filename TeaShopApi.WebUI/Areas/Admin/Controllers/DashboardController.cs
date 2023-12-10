using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage1 = await client.GetAsync("https://localhost:7109/api/Stat/TDrinkAvgPrice");
            var jsondata1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.v1 = jsondata1;


            var responseMessage2 = await client.GetAsync("https://localhost:7109/api/Stat/TDrinkCount");
            var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.v2 = jsondata2;


            var responseMessage3 = await client.GetAsync("https://localhost:7109/api/Stat/TLastDrinkName");
            var jsondata3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.v3 = jsondata3;


            var responseMessage4 = await client.GetAsync("https://localhost:7109/api/Stat/TMaxPriceDrink");
            var jsondata4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.v4 = jsondata4;

            return View();
        }
    }
}
