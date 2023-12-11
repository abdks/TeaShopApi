using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.DtoLayer.BreakFastDtos;
using TeaShopApi.DtoLayer.DrinksDtos;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinksService _drinksService;

        public DrinksController(IDrinksService drinksService)
        {
            _drinksService = drinksService;
        }
        [HttpGet]
        public IActionResult DrinksList()
        {
            var values = _drinksService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDrinks(CreateDrinksDto createDrinksDto)
        {
           Drinks drinks = new Drinks()
           {
               Description = createDrinksDto.Description,
               Title = createDrinksDto.Title,
               ImageUrl = createDrinksDto.ImageUrl,
               Price = createDrinksDto.Price
           };
            _drinksService.TInsert(drinks);
            return Ok("İçecek Öğesi Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteDrinks(int id)
        {
            var value = _drinksService.TGetById(id);
            _drinksService.TDelete(value);
            return Ok("İçecek Öğesi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDrinks(int id)
        {
            var value = _drinksService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateDrinks(UpdateDrinksDto updateDrinksDto)
        {
            Drinks Drinks = new Drinks()
            {
                DrinksID = updateDrinksDto.DrinksID,
                Description = updateDrinksDto.Description,
                Title = updateDrinksDto.Title,
                ImageUrl = updateDrinksDto.ImageUrl,
                Price = updateDrinksDto.Price

            };
            _drinksService.TUpdate(Drinks);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
