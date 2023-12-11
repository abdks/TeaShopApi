using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class DrinkkController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DrinkkController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7109/api/Drinks");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultDrinkDto>>(jsonData);
				//Deserialize : bizim json 
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateDrink()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateDrink(CreateDrinkDto createDrinkDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsondata = JsonConvert.SerializeObject(createDrinkDto);
			StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
			var responsemessage = await client.PostAsync("https://localhost:7109/api/Drinks", content);
			if (responsemessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteDrinks(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7109/api/Drinks?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{ return RedirectToAction("Index"); }
			return View();

		}
		[HttpGet]
		public async Task<IActionResult> UpdateDrinks(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7109/api/Drinks/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateDrinkDto>(jsondata);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateDrinks(UpdateDrinkDto updateDrinkDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsondata = JsonConvert.SerializeObject(updateDrinkDto);
			StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7109/api/Drinks/", content);
			if (responseMessage.IsSuccessStatusCode)
			{ return RedirectToAction("Index"); }
			return View();


		}

	}
}
