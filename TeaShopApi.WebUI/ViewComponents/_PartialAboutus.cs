using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShopApi.WebUI.Dtos.AboutPageDtos;
using TeaShopApi.WebUI.Dtos.MainPageDtos;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _PartialAboutusViewComponent :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PartialAboutusViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/AboutPage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutPageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }

}
