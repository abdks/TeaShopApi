using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApiDataAccessLayer.Abstract;
using TeaShopApiDataAccessLayer.Context;

namespace TeaShopApiDataAccessLayer.EntityFramework
{
    public class EfStatiscDal : IStatiscDal
    {
        private readonly TeaContext _teaContext;

        public EfStatiscDal(TeaContext teaContext)
        {
            _teaContext = teaContext;
        }

        public decimal DrinkAvgPrice()
        {
            decimal value = _teaContext.Drinks.Average(x => x.DrinkPrice);
            return value;
        }

        public int DrinkCount()
        {
            int value = _teaContext.Drinks.Count();
            return value;
        }

        public string LastDrinkName()
        {
            string value = _teaContext.Drinks.OrderByDescending(x => x.DrinkID).Select(y => y.DrinkName).Take(1).FirstOrDefault();
            return value;
        }

        public string MaxPriceDrink()
        {
            decimal price = _teaContext.Drinks.Max(x => x.DrinkPrice);
            string value = _teaContext.Drinks.Where(x => x.DrinkPrice == price).Select(y => y.DrinkName).FirstOrDefault();
            return value;
        }
    }
}
