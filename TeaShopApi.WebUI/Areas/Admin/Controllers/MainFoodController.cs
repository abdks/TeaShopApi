using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.MainFoodDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MainFoodController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MainFoodController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/MainFood");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMainFoodDto>>(jsonData);
                //Deserialize : bizim json 
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateMainFood()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMainFood(CreateMainFoodDto createMainFoodDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createMainFoodDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://localhost:7109/api/MainFood", content);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteMainFood(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7109/api/MainFood?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            { return RedirectToAction("Index"); }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateMainFood(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/MainFood/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateMainFoodDto>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMainFood(UpdateMainFoodDto updateMainFoodDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateMainFoodDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7109/api/MainFood/", content);
            if (responseMessage.IsSuccessStatusCode)
            { return RedirectToAction("Index"); }
            return View();


        }
    }
}
