﻿    using Microsoft.EntityFrameworkCore;
using one_to_many.Entities;
using relation_one_to_many.Entities;

namespace one_to_many.Repositories.db
{
    public class SystemDbContext : DbContext
    {

        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }

    }
}
