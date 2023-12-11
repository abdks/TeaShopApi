using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.AboutPageDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutPageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutPageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/AboutPage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutPageDto>>(jsonData);
                //Deserialize : bizim json 
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateAboutPage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAboutPage(CreateAboutPageDto createAboutPageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createAboutPageDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://localhost:7109/api/AboutPage", content);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteAboutPage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7109/api/AboutPage?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            { return RedirectToAction("Index"); }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateAboutPage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/AboutPage/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutPageDto>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAboutPage(UpdateAboutPageDto updateAboutPageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateAboutPageDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7109/api/AboutPage/", content);
            if (responseMessage.IsSuccessStatusCode)
            { return RedirectToAction("Index"); }
            return View();


        }
    }
}
