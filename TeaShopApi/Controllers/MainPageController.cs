using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.DtoLayer.MainPageDtos;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainPageController : ControllerBase
    {
        private readonly IMainPageService _mainPageService;

        public MainPageController(IMainPageService mainPageService)
        {
            _mainPageService = mainPageService;
        }

        [HttpGet]
        public IActionResult MainPageList()
        {
            var values = _mainPageService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMainPage(CreateMainPageDto createMainPageDto)
        {
            MainPage MainPage = new MainPage()
            {
                Title = createMainPageDto.Title,
                Description = createMainPageDto.Description,
                ImageUrl = createMainPageDto.ImageUrl,



            };
            _mainPageService.TInsert(MainPage);
            return Ok("Ana Sayfa Öğesi Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteMainPage(int id)
        {
            var value = _mainPageService.TGetById(id);
            _mainPageService.TDelete(value);
            return Ok("Ana Sayfa Öğesi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMainPage(int id)
        {
            var value = _mainPageService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateMainPage(UpdateMainPageDto updateMainPageDto)
        {
            MainPage MainPage = new MainPage()
            {
                Title = updateMainPageDto.Title,
                Description = updateMainPageDto.Description,
                ImageUrl = updateMainPageDto.ImageUrl,
                MainPageID = updateMainPageDto.MainPageID

            };
            _mainPageService.TUpdate(MainPage);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
