using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TeaShopApiEntityLayer.Concrete;

namespace TeaShopApiDataAccessLayer.Context
{
    public class TeaContext: DbContext
    {
     //   override//Yine aynı işlevi yapan kendi metodumuzu oluşturuyoruz en güzel örneği identity
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ABDULLAH;initial Catalog=TeaShopDb;integrated Security=true;");

        }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Message> Messages { get; set; }    
        public  DbSet<Question> Questions { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<MainPage> MainPages { get; set; }

        public DbSet<Services> Services { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Chefs> Chefs { get; set; }

    }
}
