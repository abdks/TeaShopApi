using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.DtoLayer.EventsDtos;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpGet]
        public IActionResult EventsList()
        {
            var values = _eventService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateEvents(CreateEventsDto createEventsDto)
        {
            Events events = new Events()
            {
                Title = createEventsDto.Title,
                Price = createEventsDto.Price,
                Description = createEventsDto.Description,
                Image = createEventsDto.Image
            };
            _eventService.TInsert(events);
            return Ok("Etkinlik Öğesi Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteEvents(int id)
        {
            var value = _eventService.TGetById(id);
            _eventService.TDelete(value);
            return Ok("Etkinlik Öğesi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetEvents(int id)
        {
            var value = _eventService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateEvents(UpdateEventsDto updateEventsDto)
        {
            Events events = new Events()
            {
                Title = updateEventsDto.Title,
                Price = updateEventsDto.Price,
                Description = updateEventsDto.Description,
                Image = updateEventsDto.Image,
                EventsID = updateEventsDto.EventsID
            };
            _eventService.TUpdate(events);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
