using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShopApi.WebUI.Dtos.BreakFastDtos;
using TeaShopApi.WebUI.Dtos.DessertsDtos;
using TeaShopApi.WebUI.Dtos.DrinkDtos;
using TeaShopApi.WebUI.Dtos.MainFoodDtos;
using TeaShopApi.WebUI.Dtos.ServicesDtos;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class MenuViewModel
    {
        public List<ResultDrinkDto> Drinks { get; set; }
        public List<ResultBreakFastDto> BreakFast { get; set; }
        public List<ResultDessertsDto> Desserts { get; set; }
        public List<ResultMainFoodDto> MainFood { get; set; }
        // Diğer tablolar için gerektiği kadar property ekleyebilirsiniz.
    }
    public class _PartialMenu : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PartialMenu(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            // Servisler tablosunu çek
            var DrinksResponse = await client.GetAsync("https://localhost:7109/api/Drinks");
            List<ResultDrinkDto> services = new List<ResultDrinkDto>();

            if (DrinksResponse.IsSuccessStatusCode)
            {
                var servicesJsonData = await DrinksResponse.Content.ReadAsStringAsync();
                services = JsonConvert.DeserializeObject<List<ResultDrinkDto>>(servicesJsonData);
            }

            // Diğer tabloyu çek (örneğin)
            var BreakfastResponse = await client.GetAsync("https://localhost:7109/api/BreakFast");
            List<ResultBreakFastDto> otherTableData = new List<ResultBreakFastDto>();

            if (BreakfastResponse.IsSuccessStatusCode)
            {
                var otherTableJsonData1 = await BreakfastResponse.Content.ReadAsStringAsync();
                otherTableData = JsonConvert.DeserializeObject<List<ResultBreakFastDto>>(otherTableJsonData1);
            }

            var DessertsResponse = await client.GetAsync("https://localhost:7109/api/Desserts");
            List<ResultDessertsDto> otherTableData1 = new List<ResultDessertsDto>();

            if (DessertsResponse.IsSuccessStatusCode)
            {
                var otherTableJsonData2 = await DessertsResponse.Content.ReadAsStringAsync();
                otherTableData1 = JsonConvert.DeserializeObject<List<ResultDessertsDto>>(otherTableJsonData2);
            }

            var MainFoodResponse = await client.GetAsync("https://localhost:7109/api/MainFood");
            List<ResultMainFoodDto> otherTableData2 = new List<ResultMainFoodDto>();

            if (MainFoodResponse.IsSuccessStatusCode)
            {
                var otherTableJsonData3 = await MainFoodResponse.Content.ReadAsStringAsync();
                otherTableData2 = JsonConvert.DeserializeObject<List<ResultMainFoodDto>>(otherTableJsonData3);
            }

            // ViewModel oluştur ve View'e gönder
            var viewModel = new MenuViewModel
            {
               Drinks = services,
               BreakFast = otherTableData,
               Desserts = otherTableData1,
               MainFood = otherTableData2
            };

            return View(viewModel);
        }
    }
    }

