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
    public class BreakFastManager : IBreakFastService
    {
        private readonly IBreakFastDal breakFastDal;

        public BreakFastManager(IBreakFastDal breakFastDal)
        {
            this.breakFastDal = breakFastDal;
        }

        public void TDelete(BreakFast entity)
        {
           breakFastDal.Delete(entity);
        }

        public BreakFast TGetById(int id)
        {
          return breakFastDal.GetById(id);
        }

        public List<BreakFast> TGetListAll()
        {
            return breakFastDal.GetListAll();
        }

        public void TInsert(BreakFast entity)
        {
            breakFastDal.Insert(entity);
        }

        public void TUpdate(BreakFast entity)
        {
           breakFastDal.Update(entity);
        }
    }
}
