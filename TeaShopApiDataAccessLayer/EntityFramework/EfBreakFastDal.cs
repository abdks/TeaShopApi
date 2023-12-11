using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApiDataAccessLayer.Abstract;
using TeaShopApiDataAccessLayer.Concrete;
using TeaShopApiDataAccessLayer.Context;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApiDataAccessLayer.EntityFramework
{
    public class EfBreakFastDal : GenericRepository<BreakFast>, IBreakFastDal
    {
        public EfBreakFastDal(TeaContext context) : base(context)
        {
        }
    
    }
}

