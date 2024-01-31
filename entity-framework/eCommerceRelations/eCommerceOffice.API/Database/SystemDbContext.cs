using eCommerceOffice.API.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceOffice.API.Database;

public class SystemDbContext : DbContext
{
    public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
    {
    }

    public DbSet<Class> Classes { get; set; }
    public DbSet<Collaborator> Collaborators { get; set; }
    public DbSet<CollaboratorSector> CollaboratorsSectors { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region CollaboratorSector

        modelBuilder.Entity<Collaborator>()
            .HasMany(c => c.CollaboratorSectors)
            .WithOne(cs => cs.Collaborator)
            .HasForeignKey(cs => cs.CollaboratorId);

        modelBuilder.Entity<Sector>()
            .HasMany(s => s.CollaboratorSector)
            .WithOne(cs => cs.Sector)
            .HasForeignKey(cs => cs.SectorId);

        modelBuilder.Entity<CollaboratorSector>()
            .HasKey(cs => new { cs.SectorId, cs.CollaboratorId });

        #endregion

    }
}
