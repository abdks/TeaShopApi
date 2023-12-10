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
    public class MainPageManager : IMainPageService
    {
        private readonly IMainPageDal _mainPageDal;

        public MainPageManager(IMainPageDal mainPageDal)
        {
            _mainPageDal = mainPageDal;
        }

        public void TDelete(MainPage entity)
        {
            _mainPageDal.Delete(entity);
        }

        public MainPage TGetById(int id)
        {
           return _mainPageDal.GetById(id);
        }

        public List<MainPage> TGetListAll()
        {
            return _mainPageDal.GetListAll();
        }

        public void TInsert(MainPage entity)
        {
          _mainPageDal.Insert(entity);
        }

        public void TUpdate(MainPage entity)
        {
           _mainPageDal.Update(entity);
        }
    }
}
