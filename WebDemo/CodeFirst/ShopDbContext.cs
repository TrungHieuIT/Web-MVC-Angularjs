using System.Data.Entity;
using WebDemo.Models;

namespace Shop.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("ShopConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }



        

        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<AutoIdOrder> AutoIdOrder { get; set; }
        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            //builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            //builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            //builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            //builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
        }


    }
}