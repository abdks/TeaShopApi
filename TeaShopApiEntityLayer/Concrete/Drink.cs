using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApiEntityLayer.Concrete
{
    public class Drink
    {
        public int DrinkID { get; set; }
        public string DrinkName { get; set; }
        public string DrinkPrice { get; set; }
        public string DrinkImageUrl { get; set; }
    }
}
