using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.DtoLayer.DrinksDtos;
using TeaShopApi.DtoLayer.MessageDtos;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
              SenderName = createMessageDto.SenderName,
              MessageSubject = createMessageDto.MessageSubject,
              MessageDetail = createMessageDto.MessageDetail,
              MessageEmail = createMessageDto.MessageEmail,
              MessageSendDate = createMessageDto.MessageSendDate

            };
            _messageService.TInsert(message);
            return Ok("Mesajınız Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Mesaj Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
                SenderName = updateMessageDto.SenderName,
                MessageSubject = updateMessageDto.MessageSubject,
                MessageDetail = updateMessageDto.MessageDetail,
                MessageEmail = updateMessageDto.MessageEmail,
                MessageSendDate = updateMessageDto.MessageSendDate,
                MessageID = updateMessageDto.MessageID

            };
            _messageService.TUpdate(message);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
