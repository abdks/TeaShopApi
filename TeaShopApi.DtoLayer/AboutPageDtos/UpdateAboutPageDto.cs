using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DtoLayer.AboutPageDtos
{
    public class UpdateAboutPageDto
    {
        public int AboutPageID { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string No { get; set; }
    }
}
