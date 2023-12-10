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
    public class EventsManager : IEventService
    {
        private readonly IEventDal _eventDal;

        public EventsManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public void TDelete(Events entity)
        {
            _eventDal.Delete(entity);
        }

        public Events TGetById(int id)
        {
         return _eventDal.GetById(id);
        }

        public List<Events> TGetListAll()
        {
           return _eventDal.GetListAll();
        }

        public void TInsert(Events entity)
        {
          _eventDal.Insert(entity);
        }

        public void TUpdate(Events entity)
        {
          _eventDal.Update(entity);
        }
    }
}
