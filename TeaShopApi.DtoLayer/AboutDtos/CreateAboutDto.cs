using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DtoLayer.AboutDtos
{
    public class CreateAboutDto
    {
        public string Adress { get; set; }
        public string No { get; set; }
        public string Mail { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Linkedln { get; set; }
    }
}
