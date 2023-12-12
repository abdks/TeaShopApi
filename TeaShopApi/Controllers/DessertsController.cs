﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.DtoLayer.DessertsDtos;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DessertsController : ControllerBase
    {
        private readonly IDessertsService _dessertsService;

        public DessertsController(IDessertsService dessertsService)
        {
            _dessertsService = dessertsService;
        }
        [HttpGet]
        public IActionResult DessertsList()
        {
            var values = _dessertsService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDessert(CreateDessertsDto createDessertsDto)
        {
           Desserts desserts = new Desserts()
           {
               Description = createDessertsDto.Description,
               Title = createDessertsDto.Title,
               ImageUrl = createDessertsDto.ImageUrl,
               Price = createDessertsDto.Price
           };
            _dessertsService.TInsert(desserts);
            return Ok("Tatlı Öğesi Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteDesserts(int id)
        {
            var value = _dessertsService.TGetById(id);
            _dessertsService.TDelete(value);
            return Ok("Tatlı Öğesi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDesserts(int id)
        {
            var value = _dessertsService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateDesserts(UpdateDessertsDto updateDessertsDto)
        {
            Desserts Desserts = new Desserts()
            {
                DessertsID = updateDessertsDto.DessertsID,
                Description = updateDessertsDto.Description,
                Title = updateDessertsDto.Title,
                ImageUrl = updateDessertsDto.ImageUrl,
                Price = updateDessertsDto.Price

            };
            _dessertsService.TUpdate(Desserts);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
