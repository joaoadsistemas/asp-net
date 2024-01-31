using eCommerceOffice.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceOffice.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

   public DbSet<Class> Classes { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<CollaboratorSector> CollaboratorsSectors { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-ESPF03F; Database=eCommerceOffice; trustServerCertificate=true; Integrated Security=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           
            // CollaboratorSector Muitos para muitos EF <5.0
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

        

            //Collaborator Class Many to Many EF 5+
            modelBuilder.Entity<Collaborator>().HasMany(c => c.Classes).WithMany(c => c.Collaborators);


            //Collaborator Vehicle Many to Many with Data EF 5+
            modelBuilder.Entity<Collaborator>().HasMany(c => c.Vehicles)
                .WithMany(v => v.Collaborators)
                .UsingEntity<CollaboratorVehicle>(
                    q => q.HasOne(cv => cv.Vehicle).WithMany(v => v.CollaboratorVehicles).HasForeignKey(cv => cv.VehicleId),   
                    q => q.HasOne(cv => cv.Collaborator).WithMany(c => c.CollaboratorVehicles).HasForeignKey(cv => cv.CollaboratorId),
                    q => q.HasKey(cv => new { cv.CollaboratorId, cv.VehicleId })
                );
        }
}