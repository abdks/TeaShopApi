using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;
using System.Text.Unicode;
using TeaShopApi.WebUI.Dtos.QuestionDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class QuestionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuestionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IActionResult> Index()
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/Question");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultQuestionDto>>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateQuestion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDto createQuestionDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createQuestionDto);
            StringContent content= new StringContent(jsondata, Encoding.UTF8,"application/json");
            var responsemessage = await client.PostAsync("https://localhost:7109/api/Question", content);
            if(responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult>DeleteQuestion(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7109/api/Question?id=" + id);
            if(responseMessage.IsSuccessStatusCode)
            { return RedirectToAction("Index"); }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateQuestion(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/Question/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateQuestionDto>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateQuestionDto);
            StringContent content  = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7109/api/Question/", content);
            if(responseMessage.IsSuccessStatusCode )
            { return RedirectToAction("Index"); }
            return View();


        }
    }
}
