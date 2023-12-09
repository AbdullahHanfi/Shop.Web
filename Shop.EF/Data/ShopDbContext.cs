using Shop.Core.ModelConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Models;

namespace Shop.EF.Data
{
    public class ShopDbContext : IdentityDbContext<User>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> Options)
            : base(Options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new ProductPhotosConfig());

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPhotos> ProductsPhotos { get; set; }

    }
}
