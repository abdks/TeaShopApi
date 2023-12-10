using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.DtoLayer.AboutDtos;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About About = new About()
            {

                Adress = createAboutDto.Adress,
                No = createAboutDto.No,
                Mail = createAboutDto.Mail,
                Twitter = createAboutDto.Twitter,
                Facebook = createAboutDto.Facebook,
                Instagram = createAboutDto.Instagram,
                Linkedln    = createAboutDto.Linkedln
             
            };
            _aboutService.TInsert(About);
            return Ok("Hakkında Öğesi Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkında Öğesi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About About = new About()
            {
                Adress = updateAboutDto.Adress,
                No = updateAboutDto.No,
                Mail = updateAboutDto.Mail,
                Twitter = updateAboutDto.Twitter,
                Facebook = updateAboutDto.Facebook,
                Instagram = updateAboutDto.Instagram,
                Linkedln = updateAboutDto.Linkedln,
                AboutID = updateAboutDto.AboutID

            };
            _aboutService.TUpdate(About);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
