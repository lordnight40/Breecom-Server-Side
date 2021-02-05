using Microsoft.EntityFrameworkCore;
using otec.egory.api.dto.Entities;

namespace otec.egory.api.dto
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne<Brand>(product => product.Brand)
                .WithMany(brand => brand.Products);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}