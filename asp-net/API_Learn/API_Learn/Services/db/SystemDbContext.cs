using DSLearn.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
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
        DbSet<Topic> Topics { get; set; }
        DbSet<Reply> Replys { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Enrollment>()
            .HasKey(e => new { e.OfferId, e.UserId });

            builder.Entity<Enrollment>()
                .HasOne(e => e.Offer)
                .WithMany(o => o.Enrollments) 
                .HasForeignKey(e => e.OfferId);

            builder.Entity<Enrollment>()
                .HasOne(e => e.User)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.UserId);






            builder.Entity<Course>()
                .HasKey(c => c.Id);

            builder.Entity<Course>()
                .HasMany(c => c.Offers)
                .WithOne(o => o.Course)
                .HasForeignKey(o => o.CourseId); ;


            builder.Entity<Task>()
                .ToTable("tb_task");



            builder.Entity<Deliver>()
                .HasKey(d => d.Id);

            builder.Entity<Deliver>()
                .HasOne(d => d.Lesson)
                .WithMany(l => l.Deliveries)
                .HasForeignKey(d => d.LessonId); ;

            builder.Entity<Deliver>()
               .HasOne(d => d.Enrollment)
               .WithMany(e => e.Deliveries);





            builder.Entity<Lesson>()
                .HasKey(l => l.Id);
                

            builder.Entity<Lesson>()
                 .HasOne(l => l.Section)
                 .WithMany(s => s.Lessons)
                 .HasForeignKey(l => l.SectionId); ;

            builder.Entity<Lesson>()
                .HasMany(s => s.EnrollmentsDone)
                .WithMany(e => e.LessonsDone);

            builder.Entity<Lesson>()
                .HasMany(s => s.Deliveries)
                .WithOne(d => d.Lesson)
                .HasForeignKey(d => d.LessonId); ;

            builder.Entity<Lesson>()
                .HasMany(s => s.Topics)
                .WithOne(t => t.Lesson)
                .HasForeignKey(t => t.LessonId); ;





            builder.Entity<Notification>()
                .HasKey(n => n.Id);

            builder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);





            builder.Entity<Offer>().HasMany(o => o.Users)
               .WithMany(u => u.Offers)
               .UsingEntity<Enrollment>(
                   x => x.HasOne(e => e.User).WithMany(u => u.Enrollments).HasForeignKey(e => e.UserId),
                   x => x.HasOne(e => e.Offer).WithMany(o => o.Enrollments).HasForeignKey(o => o.OfferId),
                   x => x.HasKey(e => new { e.OfferId, e.UserId})
               );

            builder.Entity<Offer>()
                .HasOne(o => o.Course)
                .WithMany(c => c.Offers)
                .HasForeignKey(o => o.CourseId); ;

            builder.Entity<Offer>()
                .HasMany(o => o.Resources)
                .WithOne(r => r.Offer)
                .HasForeignKey(r => r.OfferId); ;

            builder.Entity<Offer>()
                .HasMany(o => o.Topics)
                .WithOne(t => t.Offer)
                .HasForeignKey(t => t.OfferId); ;





            builder.Entity<Reply>()
               .HasKey(r => r.Id);

            builder.Entity<Reply>()
                .HasOne(r => r.Topic)
                .WithMany(r => r.Replies)
                .HasForeignKey(r => r.TopicId);

            builder.Entity<Reply>()
                .HasMany(r => r.Likes);

            builder.Entity<Reply>()
                .HasOne(r => r.Author)
                .WithMany()
                .HasForeignKey(r => r.AuthorId); ;


            builder.Entity<Resource>()
               .HasKey(r => r.Id);

            builder.Entity<Resource>()
                .HasOne(r => r.Offer)
                .WithMany(o => o.Resources)
                .HasForeignKey(r => r.OfferId); ;

            builder.Entity<Resource>()
                .HasMany(r => r.Sections)
                .WithOne(s => s.Resource)
                .HasForeignKey(s => s.ResourceId);


            builder.Entity<Section>()
                .HasOne(s => s.PreRequisite)
                .WithMany()
                .HasForeignKey(s => s.PreRequisiteId);

            builder.Entity<Section>()
                .HasOne(s => s.Resource)
                .WithMany(r => r.Sections)
                .HasForeignKey(s => s.ResourceId);

            builder.Entity<Section>()
                .HasMany(s => s.Lessons)
                .WithOne(l => l.Section)
                .HasForeignKey(l => l.SectionId);






            builder.Entity<Topic>()
                .HasKey(t => t.Id);

            builder.Entity<Topic>()
                .HasOne(t => t.Lesson)
                .WithMany(l => l.Topics)
                .HasForeignKey(t => t.LessonId);

            builder.Entity<Topic>()
                .HasOne(t => t.Offer)
                .WithMany(o => o.Topics)
                .HasForeignKey(t => t.OfferId);

            builder.Entity<Topic>()
                .HasMany(t => t.Likes);

            builder.Entity<Topic>()
                .HasOne(t => t.Author)
                .WithMany()
                .HasForeignKey(t => t.AuthorId);

            builder.Entity<Topic>()
                .HasOne(t => t.Reply)
                .WithMany()
                .HasForeignKey(t => t.ReplyId);

            builder.Entity<Topic>()
                .HasMany(t => t.Replies)
                .WithOne(r => r.Topic)
                .HasForeignKey(r => r.TopicId);




        }




    }
}
