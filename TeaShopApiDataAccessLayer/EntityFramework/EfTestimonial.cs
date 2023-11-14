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
    public class EfTestimonial : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EfTestimonial(TeaContext context) : base(context)
        {
        }
    }
}
