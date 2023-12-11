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
    public class DessertsManager : IDessertsService
    {
        private readonly IDessertsDal _dessertsDal;

        public DessertsManager(IDessertsDal dessertsDal)
        {
            _dessertsDal = dessertsDal;
        }

        public void TDelete(Desserts entity)
        {
          _dessertsDal.Delete(entity);
        }

        public Desserts TGetById(int id)
        {
            return _dessertsDal.GetById(id);
        }

        public List<Desserts> TGetListAll()
        {
           return _dessertsDal.GetListAll();
        }

        public void TInsert(Desserts entity)
        {
           _dessertsDal.Insert(entity);
        }

        public void TUpdate(Desserts entity)
        {
           _dessertsDal.Update(entity);
        }
    }
}
