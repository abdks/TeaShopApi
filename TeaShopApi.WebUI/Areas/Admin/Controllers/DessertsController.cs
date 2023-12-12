using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.DessertsDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DessertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DessertsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/Desserts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDessertsDto>>(jsonData);
                //Deserialize : bizim json 
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateDesserts()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDesserts(CreateDessertsDto createDessertsDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createDessertsDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://localhost:7109/api/Desserts", content);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteDesserts(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7109/api/Desserts?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            { return RedirectToAction("Index"); }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateDesserts(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/Desserts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDessertsDto>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDesserts(UpdateDessertsDto updateDessertsDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateDessertsDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7109/api/Desserts/", content);
            if (responseMessage.IsSuccessStatusCode)
            { return RedirectToAction("Index"); }
            return View();


        }
    }
}
