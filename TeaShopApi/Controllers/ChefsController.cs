using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.DtoLayer.ChefsDtos;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly IChefService _chefService;

        public ChefsController(IChefService chefService)
        {
            _chefService = chefService;
        }
        [HttpGet]
        public IActionResult ChefsList()
        {
            var values = _chefService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateChefs(CreateChefsDto createChefsDto)
        {
            Chefs chefs = new Chefs()
            {
                NameSurname = createChefsDto.NameSurname,
                Description = createChefsDto.Description,
                Unvan = createChefsDto.Unvan,
                ImageUrl = createChefsDto.ImageUrl

            };
            _chefService.TInsert(chefs);
            return Ok("Yeni Şef Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteChefs(int id)
        {
            var value = _chefService.TGetById(id);
            _chefService.TDelete(value);
            return Ok("Şef Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetChefs(int id)
        {
            var value = _chefService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateChefs(UpdateChefsDto updateChefsDto)
        {
            Chefs Chefs = new Chefs()
            {
                ChefsID = updateChefsDto.ChefsID,
                NameSurname = updateChefsDto.NameSurname,
                Description = updateChefsDto.Description,
                ImageUrl= updateChefsDto.ImageUrl,
                Unvan = updateChefsDto.Unvan

            };
            _chefService.TUpdate(Chefs);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
