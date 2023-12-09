using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using tparf.Api.Entities;

namespace tparf.Api.Data
{
    public class TparfDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public TparfDbContext(DbContextOptions<TparfDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductManufacturer> ProductManufacturers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<TpaProduct> TpaProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TokenInfo> TokenInfo { get; set; }
    }   
}
