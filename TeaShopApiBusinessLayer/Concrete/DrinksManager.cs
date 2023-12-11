using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiDataAccessLayer.Abstract;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApiBusinessLayer.Concrete
{
    public class DrinksManager : IDrinksService
    {
        private readonly IDrinkDal _drinkDal;

        public DrinksManager(IDrinkDal drinkDal)
        {
            _drinkDal = drinkDal;
        }

        public void TDelete(Drinks entity)
        {
           _drinkDal.Delete(entity);
        }

        public Drinks TGetById(int id)
        {
           return _drinkDal.GetById(id);
        }

        public List<Drinks> TGetListAll()
        {
         return _drinkDal.GetListAll();
        }

        public void TInsert(Drinks entity)
        {
           _drinkDal.Insert(entity);
        }

        public void TUpdate(Drinks entity)
        {
            _drinkDal.Update(entity);
        }

    }
}
