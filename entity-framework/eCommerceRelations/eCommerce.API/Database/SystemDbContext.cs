using eCommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database;

public class SystemDbContext : DbContext
{
    public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
    {
        
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<DeliverAddress> DeliverAddresses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(
            new Department
            {
                Id = 4,
                Name = "furniture"
            },
            new Department
            {
                Id = 5,
                Name = "fashion"
            },
            new Department
            {
                Id = 6,
                Name = "market"
            },
            new Department
            {
                Id = 7,
                Name = "smartphones"
            }
            );
    }
}