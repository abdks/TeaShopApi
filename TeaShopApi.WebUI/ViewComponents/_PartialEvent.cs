using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShopApi.WebUI.Dtos.EventsDtos;
using TeaShopApi.WebUI.Dtos.ServicesDtos;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _PartialEvent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PartialEvent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/Events");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEventsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
