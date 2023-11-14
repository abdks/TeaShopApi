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
    public class EfQuestionDal : GenericRepository<Question>, IQuestionDal
    {
        public EfQuestionDal(TeaContext context) : base(context)
        {
        }
    }
}
