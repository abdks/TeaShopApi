using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.BreakFastDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BreakFastController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BreakFastController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/BreakFast");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBreakFastDto>>(jsonData);
                //Deserialize : bizim json 
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateBreakFast()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBreakFast(CreateBreakFastDto createBreakFastDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createBreakFastDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://localhost:7109/api/BreakFast", content);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteBreakFast(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7109/api/BreakFast?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            { return RedirectToAction("Index"); }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateBreakFast(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/BreakFast/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBreakFastDto>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBreakFast(UpdateBreakFastDto updateBreakFastDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateBreakFastDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7109/api/BreakFast/", content);
            if (responseMessage.IsSuccessStatusCode)
            { return RedirectToAction("Index"); }
            return View();


        }
    }
}
