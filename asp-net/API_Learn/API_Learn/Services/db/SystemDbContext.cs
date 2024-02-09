using DSLearn.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = DSLearn.Entities.Task;


namespace DSLearn.Services.db
{
    public class SystemDbContext : IdentityDbContext<User>
    {

        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options) { }

        DbSet<Content> Contents { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Deliver> Delivers { get; set; }
        DbSet<Enrollment> Enrollments { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<Offer> Offers { get; set; }
        DbSet<Resource> Resources { get; set; }
        DbSet<Section> Sections { get; set; }
        DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }




    }
}
