using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using TeaShopApi.DtoLayer.BreakFastDtos;
using TeaShopApi.DtoLayer.MainFoodDtos;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainFoodController : ControllerBase
    {
        private readonly IMainFoodService _mainFoodService;

        public MainFoodController(IMainFoodService mainFoodService)
        {
            _mainFoodService = mainFoodService;
        }
        [HttpGet]
        public IActionResult MainFoodList()
        {
            var values = _mainFoodService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMainFood(CreateMainFoodDto createMainFoodDto)
        {
           MainFood mainFood = new MainFood()
           {
               Description = createMainFoodDto.Description,
               Title = createMainFoodDto.Title,
               ImageUrl = createMainFoodDto.ImageUrl,
               Price = createMainFoodDto.Price
           };
            _mainFoodService.TInsert(mainFood);
            return Ok("Ana Yemek Öğesi Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteMainFood(int id)
        {
            var value = _mainFoodService.TGetById(id);
            _mainFoodService.TDelete(value);
            return Ok("Ana Yemek Öğesi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMainFood(int id)
        {
            var value = _mainFoodService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateMainFood(UpdateMainFoodDto updateMainFoodDto)
        {
            MainFood MainFood = new MainFood()
            {
                MainFoodID = updateMainFoodDto.MainFoodID,
                Description = updateMainFoodDto.Description,
                Title = updateMainFoodDto.Title,
                ImageUrl = updateMainFoodDto.ImageUrl,
                Price = updateMainFoodDto.Price

            };
            _mainFoodService.TUpdate(MainFood);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
