using Microsoft.EntityFrameworkCore;
using relation_one_to_many.Entities;

namespace relation_one_to_many.Repositories
{
    public class SystemDbContext : DbContext
    {

        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
        {
                
        }

        public DbSet<User> Users { get; set; }

    }
}
