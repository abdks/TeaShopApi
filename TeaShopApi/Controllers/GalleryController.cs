using Microsoft.AspNetCore.Mvc;
using TeaShopApi.DtoLayer.GalleryDtos;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GalleryController : Controller
	{
		private readonly IGalleryService _galleryService;

		public GalleryController(IGalleryService galleryService)
		{
			_galleryService = galleryService;
		}

		[HttpGet]
		public IActionResult GalleryList()
		{
			var values = _galleryService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateGallery(CreateGalleryDto createGalleryDto)
		{
			Gallery gallery = new Gallery()
			{
				ImageUrl = createGalleryDto.ImageUrl
			};
			_galleryService.TInsert(gallery);
			return Ok("Resim Öğesi Eklendi");

		}
		[HttpDelete]
		public IActionResult DeleteGallery(int id)
		{
			var value = _galleryService.TGetById(id);
			_galleryService.TDelete(value);
			return Ok("Resim Öğesi Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetGallery(int id)
		{
			var value = _galleryService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateGallery(UpdateGalleryDto updateGalleryDto)
		{
			Gallery Gallery = new Gallery()
			{
				GalleryID = updateGalleryDto.GalleryID,
				ImageUrl = updateGalleryDto.ImageUrl

			};
			_galleryService.TUpdate(Gallery);
			return Ok("Güncelleme Yapıldı");
		}
	}
}
