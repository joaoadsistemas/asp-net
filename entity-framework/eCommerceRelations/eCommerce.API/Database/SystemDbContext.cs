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


        // mudar nome da tabela
        modelBuilder.Entity<User>().ToTable("tb_user");
        // mudar atributos de uma propriedade
        modelBuilder.Entity<User>().Property(u => u.MotherName).HasColumnName("mother_name").IsRequired();
        // cpf único
        modelBuilder.Entity<User>().HasIndex(u => u.Cpf).IsUnique();
        // id é a chave primária
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        
        /*
         * RELACIONAMENTOS ENTRE TABELAS E ENTIDADES
         *
         *  tem/com    um/muitos
         *  HAS/WITH + ONE/MANY = HasOne, HasMany, WithOne, WithMany
         */

        modelBuilder.Entity<User>().HasOne(u => u.Contact).WithOne(c => c.User).HasForeignKey<Contact>(c => c.UserId).OnDelete(DeleteBehavior.ClientCascade);
        modelBuilder.Entity<User>().HasMany(u => u.DeliverAddresses).WithOne(d => d.User).HasForeignKey(d => d.UserId);
        modelBuilder.Entity<User>().HasMany(u => u.Departments).WithMany(d => d.Users);
    }
}