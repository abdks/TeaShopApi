using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DtoLayer.ChefsDtos
{
    public class UpdateChefsDto
    {
        public int ChefsID { get; set; }
        public string NameSurname { get; set; }
        public string Unvan { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
