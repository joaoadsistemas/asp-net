using ApiCatalogo.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repositories.db;

public class SystemDbContext : DbContext
{
    public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasOne(p => p.Category)
            .WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Category>().HasMany(c => c.Products)
            .WithOne(p => p.Category);
    }
}