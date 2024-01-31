using eCommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Models.FluentAPI.Database
{
    public class ECommerceFluentContext : DbContext
    {
        public ECommerceFluentContext(DbContextOptions<ECommerceFluentContext> options) : base(options)
        {
        
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DeliverAddress> DeliverAddresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable();
        }
    }
}