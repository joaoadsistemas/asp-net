using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Entities;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace VShop.ProductApi.Context
{
    public class SystemDbContext : IdentityDbContext<User>
    {

        public SystemDbContext(DbContextOptions<SystemDbContext> option) : base(option)
        {

            // DOCKER APLICAR MIGRATIONS
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ///////

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "Client", NormalizedName = "CLIENT" }
             );


            var adminId = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();

            builder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    Email = "admin@gmail.com",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, "Senha#123"),
                    EmailConfirmed = true,
                    PhoneNumber = "999999999",
                    PhoneNumberConfirmed = true,
                    NormalizedEmail = "ADMIN@GMAIL.COM"
                }
            );

            builder.Entity<User>().HasData(
                new User
                {
                    Id = clientId,
                    Email = "client@gmail.com",
                    UserName = "Client",
                    NormalizedUserName = "CLIENT",
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, "Senha#123"),
                    EmailConfirmed = true,
                    PhoneNumber = "999999999",
                    PhoneNumberConfirmed = true,
                    NormalizedEmail = "CLIENT@GMAIL.COM"
                }
            );


            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = adminId, RoleId = "1" }, // Admin role
            new IdentityUserRole<string> { UserId = clientId, RoleId = "2" } // Client role
            );

            builder.Entity<User>()
                .HasMany(u => u.Products)
                .WithMany(p => p.Users);
        }

    }
}
