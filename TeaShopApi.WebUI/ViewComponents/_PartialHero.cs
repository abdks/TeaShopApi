using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShopApi.WebUI.Dtos.AboutDtos;
using TeaShopApi.WebUI.Dtos.MainPageDtos;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _PartialHero: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PartialHero(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/MainPage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMainPageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
