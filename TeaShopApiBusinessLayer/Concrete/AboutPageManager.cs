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
    public class AboutPageManager : IAboutPageService
    {
        private readonly IAboutPageDal _aboutPageDal;

        public AboutPageManager(IAboutPageDal aboutPageDal)
        {
            _aboutPageDal = aboutPageDal;
        }

        public void TDelete(AboutPage entity)
        {
            _aboutPageDal.Delete(entity);
        }

        public AboutPage TGetById(int id)
        {
         return _aboutPageDal.GetById(id);
        }

        public List<AboutPage> TGetListAll()
        {
            return _aboutPageDal.GetListAll();
        }

        public void TInsert(AboutPage entity)
        {
            _aboutPageDal.Insert(entity);
        }

        public void TUpdate(AboutPage entity)
        {
            _aboutPageDal.Update(entity);
        }

    }
}
