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
    public class ServicesManager : IServicesService
    {
        private readonly IServicesDal _servicesDal;

        public ServicesManager(IServicesDal servicesDal)
        {
            _servicesDal = servicesDal;
        }

        public void TDelete(Services entity)
        {
          _servicesDal.Delete(entity);
        }

        public Services TGetById(int id)
        {
           return _servicesDal.GetById(id);
        }

        public List<Services> TGetListAll()
        {
            return _servicesDal.GetListAll();

        }

        public void TInsert(Services entity)
        {
          _servicesDal.Insert(entity);
        }

        public void TUpdate(Services entity)
        {
           _servicesDal.Update(entity);
        }
    }
}
