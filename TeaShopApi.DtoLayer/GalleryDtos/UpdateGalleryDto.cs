using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DtoLayer.GalleryDtos
{
	public class UpdateGalleryDto
	{
		public int GalleryID { get; set; }
		public string ImageUrl { get; set; }
	}
}
