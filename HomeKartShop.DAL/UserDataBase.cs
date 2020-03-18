using HomeKartShop.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKartShop.DAL
{
    public class UserDataBase : DbContext
    {
        public UserDataBase() : base("MyConnection")
        {
        }
        public DbSet<User> user { get; set; }
        public DbSet<State> state { get; set; }
        public DbSet<City> city { get; set; }
        public DbSet<CarouselSlider> carouselSliders { get; set; }
        public DbSet<ProductCategory> productCategory { get; set; }
        public DbSet<Inventory> inventory { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarouselSlider>().MapToStoredProcedures();
        }
    }


}
