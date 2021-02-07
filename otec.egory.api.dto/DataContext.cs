using Microsoft.EntityFrameworkCore;
using otec.egory.api.dto.Entities;

namespace otec.egory.api.dto
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=LocalStorage.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(brand => brand.Products)
                .WithOne(product => product.Brand)
                .HasForeignKey(product => product.BrandId);

            modelBuilder.Entity<Brand>()
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
    }
}