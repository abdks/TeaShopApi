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
	public class GalleryManager : IGalleryService
	{
		private readonly IGalleryDal _galleryDal;

		public GalleryManager(IGalleryDal galleryDal)
		{
			_galleryDal = galleryDal;
		}

		public void TDelete(Gallery entity)
		{
			_galleryDal.Delete(entity);
		}

		public Gallery TGetById(int id)
		{
			return _galleryDal.GetById(id);
		}

		public List<Gallery> TGetListAll()
		{
			return _galleryDal.GetListAll();
		}

		public void TInsert(Gallery entity)
		{
			_galleryDal.Insert(entity);
		}

		public void TUpdate(Gallery entity)
		{
			_galleryDal.Update(entity);
		}
	}
}
