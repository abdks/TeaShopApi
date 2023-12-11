using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.DtoLayer.BreakFastDtos;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakFastController : ControllerBase
    {
        private readonly IBreakFastService _breakFastService;

        public BreakFastController(IBreakFastService breakFastService)
        {
            _breakFastService = breakFastService;
        }
        [HttpGet]
        public IActionResult BreakFastList()
        {
            var values = _breakFastService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBreakFast(CreateBreakFastDto createBreakFastDto)
        {
           BreakFast breakFast = new BreakFast()
           {
               Description = createBreakFastDto.Description,
               Title = createBreakFastDto.Title,
               ImageUrl = createBreakFastDto.ImageUrl,
               Price = createBreakFastDto.Price
           };
            _breakFastService.TInsert(breakFast);
            return Ok("Kahvaltı Öğesi Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteBreakFast(int id)
        {
            var value = _breakFastService.TGetById(id);
            _breakFastService.TDelete(value);
            return Ok("Kahvaltı Öğesi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBreakFast(int id)
        {
            var value = _breakFastService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateBreakFast(UpdateBreakFastDto updateBreakFastDto)
        {
           BreakFast breakFast = new BreakFast()
           {
               BreakFastID = updateBreakFastDto.BreakFastID,
               Description = updateBreakFastDto.Description,
               Title = updateBreakFastDto.Title,
               ImageUrl = updateBreakFastDto.ImageUrl,
               Price = updateBreakFastDto.Price
           };
            _breakFastService.TUpdate(breakFast);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
