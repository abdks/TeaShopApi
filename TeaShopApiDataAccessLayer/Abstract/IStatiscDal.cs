using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApiDataAccessLayer.Abstract
{
    public interface IStatiscDal
    {
        int DrinkCount();
        decimal DrinkAvgPrice();
        string LastDrinkName();
        string MaxPriceDrink();

    }
}
