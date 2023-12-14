using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShopApi.WebUI.Dtos.AboutPageDtos;
using TeaShopApi.WebUI.Dtos.ChefsDtos;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _PartialChef : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PartialChef(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/Chefs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultChefsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
