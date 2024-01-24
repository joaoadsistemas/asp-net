using DSCommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSCommerce.Repositories.db
{
    public class SystemDbContext : DbContext
    {

        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
