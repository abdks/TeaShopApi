using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApiDataAccessLayer.Abstract;

namespace TeaShopApiBusinessLayer.Concrete
{
    public class StatisticsManager : IStatisticsService
    {
        private readonly IStatiscDal _statiscDal;

        public StatisticsManager(IStatiscDal statiscDal)
        {
            _statiscDal = statiscDal;
        }

        public decimal TDrinkAvgPrice()
        {
            return _statiscDal.DrinkAvgPrice();
        }

        public int TDrinkCount()
        {
            return _statiscDal.DrinkCount();
        }

        public string TLastDrinkName()
        {
            return _statiscDal.LastDrinkName();
        }

        public string TMaxPriceDrink()
        {
            return _statiscDal.MaxPriceDrink();
        }
    }
}
