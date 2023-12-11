using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApiEntityLayer.Concrete
{
    public class MenuCategory
    {
        public int MenuCategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<Menu> Menus { get; set; } // İlişkiyi temsil eden property

    }
}
