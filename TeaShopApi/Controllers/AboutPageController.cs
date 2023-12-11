using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.DtoLayer.AboutPageDtos;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutPageController : ControllerBase
    {
        private readonly IAboutPageService _aboutPageService;

        public AboutPageController(IAboutPageService aboutPageService)
        {
            _aboutPageService = aboutPageService;
        }
        [HttpGet]
        public IActionResult AboutPageList()
        {
            var values = _aboutPageService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAboutPage(CreateAboutPageDto createAboutPageDto)
        {
            AboutPage aboutPage = new AboutPage()
            {
                Description = createAboutPageDto.Description,
                ImageUrl = createAboutPageDto.ImageUrl,
                VideoUrl = createAboutPageDto.VideoUrl,
                No = createAboutPageDto.No

            };
            _aboutPageService.TInsert(aboutPage);
            return Ok("Hakkında Öğesi Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteAboutPage(int id)
        {
            var value = _aboutPageService.TGetById(id);
            _aboutPageService.TDelete(value);
            return Ok("Hakkında Öğesi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAboutPage(int id)
        {
            var value = _aboutPageService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutPageDto updateAboutPageDto)
        {
            AboutPage aboutPage = new AboutPage()
            {
                AboutPageID = updateAboutPageDto.AboutPageID,
                Description = updateAboutPageDto.Description,
                ImageUrl = updateAboutPageDto.ImageUrl,
                VideoUrl = updateAboutPageDto.VideoUrl,
                No = updateAboutPageDto.No
            };
            _aboutPageService.TUpdate(aboutPage);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
