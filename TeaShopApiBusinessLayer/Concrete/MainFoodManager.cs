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
    public class MainFoodManager : IMainFoodService
    {
        private readonly IMainFoodDal _mainFoodDal;

        public MainFoodManager(IMainFoodDal mainFoodDal)
        {
            _mainFoodDal = mainFoodDal;
        }

        public void TDelete(MainFood entity)
        {
           _mainFoodDal.Delete(entity);
        }

        public MainFood TGetById(int id)
        {
           return _mainFoodDal.GetById(id);
        }

        public List<MainFood> TGetListAll()
        {
          return  _mainFoodDal.GetListAll();
        }

        public void TInsert(MainFood entity)
        {
            _mainFoodDal.Insert (entity);
        }

        public void TUpdate(MainFood entity)
        {
            _mainFoodDal.Update (entity);
        }
    }
}
