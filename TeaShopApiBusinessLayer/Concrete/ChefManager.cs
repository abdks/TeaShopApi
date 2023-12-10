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
    public class ChefManager : IChefService
    {
        private readonly IChefDal _chefDal;

        public ChefManager(IChefDal chefDal)
        {
            _chefDal = chefDal;
        }

        public void TDelete(Chefs entity)
        {
            _chefDal.Delete(entity);
        }

        public Chefs TGetById(int id)
        {
            return _chefDal.GetById(id);
        }

        public List<Chefs> TGetListAll()
        {
            return _chefDal.GetListAll();
        }

        public void TInsert(Chefs entity)
        {
           _chefDal.Insert(entity);
        }

        public void TUpdate(Chefs entity)
        {
           _chefDal.Update(entity);
        }
    }
}
