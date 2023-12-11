using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.GalleryDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class GalleryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public GalleryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7109/api/Gallery");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultGalleryDto>>(jsonData);
				//Deserialize : bizim json 
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateGallery()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateGallery(CreateGalleryDto createGalleryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsondata = JsonConvert.SerializeObject(createGalleryDto);
			StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
			var responsemessage = await client.PostAsync("https://localhost:7109/api/Gallery", content);
			if (responsemessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteGallery(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7109/api/Gallery?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{ return RedirectToAction("Index"); }
			return View();

		}
		[HttpGet]
		public async Task<IActionResult> UpdateGallery(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7109/api/Gallery/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateGalleryDto>(jsondata);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateGallery(UpdateGalleryDto updateGalleryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsondata = JsonConvert.SerializeObject(updateGalleryDto);
			StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7109/api/Gallery/", content);
			if (responseMessage.IsSuccessStatusCode)
			{ return RedirectToAction("Index"); }
			return View();


		}
	}
}
