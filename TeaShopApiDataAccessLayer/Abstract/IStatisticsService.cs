using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApiDataAccessLayer.Abstract
{
    public interface IStatisticsService
    {
        int TDrinkCount();
        decimal TDrinkAvgPrice();
        string TLastDrinkName();
        string TMaxPriceDrink();
    }
}
