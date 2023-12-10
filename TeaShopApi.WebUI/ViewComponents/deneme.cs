using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.Text.Json.Serialization.Metadata;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class deneme : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public deneme(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/Drinks");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync(); // Note the 'await' keyword here
                var values = JsonConvert.DeserializeObject<List<ResultDrinkDto>>(jsondata);
                return View(values);
            }

            return View();
        }

    }
}
