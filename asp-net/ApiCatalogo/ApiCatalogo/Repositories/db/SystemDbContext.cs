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


        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Cars",
                ImgUrl = "https://img.com.br"
            },
            new Category
            {
                Id = 2,
                Name = "Electronics",
                ImgUrl = "https://img.com.br"
            },
            new Category
            {
                Id = 3,
                Name = "Smartphones",
                ImgUrl = "https://img.com.br"
            },
            new Category
            {
                Id = 4,
                Name = "Books",
                ImgUrl = "https://img.com.br"
            },
            new Category
            {
                Id = 5,
                Name = "Clothes",
                ImgUrl = "https://img.com.br"
            }
            );



        modelBuilder.Entity<Product>().HasData(
            new Product
            {
              Id  = 1,
              CategoryId = 1,
              Name = "Punto",
              Description = "Fiat Punto",
              RegisterData = DateTime.Now,
              Price = 25000.00,
              Stock = 2,
              ImgUrl = "https://img.com.br"
            }
            );
    }
}