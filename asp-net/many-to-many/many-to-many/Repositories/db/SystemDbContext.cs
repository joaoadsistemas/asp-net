using many_to_many.Entities;
using Microsoft.EntityFrameworkCore;
using one_to_many.Entities;

namespace one_to_many.Repositories.db
{
    public class SystemDbContext : DbContext
    {

        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Skill> Skills { get; set; }

    }
}
