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
}