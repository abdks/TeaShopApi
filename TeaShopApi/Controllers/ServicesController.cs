using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.DtoLayer.ServicesDtos;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }
        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _servicesService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateService(CreateServicesDto createServicesDto)
        {
            Services services = new Services()
            {
                Title = createServicesDto.Title,
                Description = createServicesDto.Description,
                Image = createServicesDto.Image
            };
            _servicesService.TInsert(services);
            return Ok("Hizmet Öğesi Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _servicesService.TGetById(id);
            _servicesService.TDelete(value);
            return Ok("Hizmet Öğesi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var value = _servicesService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateService(UpdateServicesDto updateServicesDto)
        {
            Services services = new Services()
            {
                Title = updateServicesDto.Title,
                Description = updateServicesDto.Description,
                Image = updateServicesDto.Image,
                ServicesID = updateServicesDto.ServicesID
            };
            _servicesService.TUpdate(services);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
