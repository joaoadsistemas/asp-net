using DSLearn.Entities;
using DSLearn.Entities.enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Emit;
using Task = DSLearn.Entities.Task;

namespace DSLearn.Repositories.db
{
    public class SystemDbContext : IdentityDbContext<User>      
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options) { }

        public DbSet<Content> Contents { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Deliver> Delivers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replys { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Topic>()
                .HasOne(t => t.Answer)
                .WithMany()
                .HasForeignKey(t => t.AnswerId);

            builder.Entity<Reply>()
                .HasOne(r => r.Topic)
                .WithMany(t => t.Replies)
                .HasForeignKey(r => r.TopicId);

            builder.Entity<Deliver>()
                .HasOne(d => d.Lesson)
                .WithMany(l => l.Deliveries)
                .HasForeignKey(d => d.LessonId);

            builder.Entity<Topic>()
                .HasOne(t => t.Lesson)
                .WithMany(l => l.Topics)
                .HasForeignKey(t => t.LessonId);

            builder.Entity<Enrollment>()
                .HasKey(e => new { e.OfferId, e.UserId });

            builder.Entity<Enrollment>()
                .HasKey(e => new { e.OfferId, e.UserId });

            builder.Entity<Enrollment>()
                .HasMany(e => e.LessonsDone)
                .WithMany(l => l.EnrollmentsDone);

            builder.Entity<Lesson>()
                .HasMany(l => l.EnrollmentsDone)
                .WithMany(e => e.LessonsDone);

            builder.Entity<Deliver>()
                .HasOne(d => d.Enrollment)
                .WithMany(e => e.Deliveries)
                .HasForeignKey(d => new { d.OfferId, d.UserId }); // Use the correct foreign key properties

            builder.Entity<User>().HasData(
                new User
                {
                    Id = "3b01910b-4e21-4cf3-a859-9a79261d0385",
                    UserName = "Alex Brown",
                    Email = "alex@gmail.com",
                    PasswordHash = "$2a$10$eACCYoNOHEqXve8aIWT8Nu3PkMXWBaOxJ9aORUYzfMQCbVBIhZ8tG"
                },
                new User
                {
                    Id = "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7",
                    UserName = "Bob Brown",
                    Email = "bob@gmail.com",
                    PasswordHash = "$2a$10$eACCYoNOHEqXve8aIWT8Nu3PkMXWBaOxJ9aORUYzfMQCbVBIhZ8tG"
                },
                new User
                {
                    Id = "a1ff4f6c-5011-4b95-9bda-2bc33693fcac",
                    UserName = "Maria Green",
                    Email = "maria@gmail.com",
                    PasswordHash = "$2a$10$eACCYoNOHEqXve8aIWT8Nu3PkMXWBaOxJ9aORUYzfMQCbVBIhZ8tG"
                }
            );

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "ROLE_STUDENT", NormalizedName = "ROLE_STUDENT" },
                new IdentityRole { Id = "2", Name = "ROLE_INSTRUCTOR", NormalizedName = "ROLE_INSTRUCTOR" },
                new IdentityRole { Id = "3", Name = "ROLE_ADMIN", NormalizedName = "ROLE_ADMIN" }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "3b01910b-4e21-4cf3-a859-9a79261d0385", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "a1ff4f6c-5011-4b95-9bda-2bc33693fcac", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "a1ff4f6c-5011-4b95-9bda-2bc33693fcac", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "a1ff4f6c-5011-4b95-9bda-2bc33693fcac", RoleId = "3" }
            );

            builder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Name = "Bootcamp HTML",
                    ImgUri = "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg",
                    ImgGrayUri = "https://upload.wikimedia.org/wikipedia/commons/1/1f/Switch-course-book-grey.svg"
                }
            );

            builder.Entity<Offer>().HasData(
                new Offer
                {
                    Id = 1,
                    Edition = "1.0",
                    StartMoment = DateTime.Parse("2020-11-20 03:00:00"),
                    EndMoment = DateTime.Parse("2021-11-20 03:00:00"),
                    CourseId = 1
                },
                new Offer
                {
                    Id = 2,
                    Edition = "2.0",
                    StartMoment = DateTime.Parse("2020-12-20 03:00:00"),
                    EndMoment = DateTime.Parse("2021-12-20 03:00:00"),
                    CourseId = 1
                }
            );

            builder.Entity<Resource>().HasData(
                new Resource
                {
                    Id = 1,
                    Title = "Trilha HTML",
                    Description = "Trilha principal do curso",
                    Position = 1,
                    imgUri = "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg",
                    Type = ResourceType.LESSON_TASK,
                    OfferId = 1
                },
                new Resource
                {
                    Id = 2,
                    Title = "Forum",
                    Description = "Tire suas dúvidas",
                    Position = 2,
                    imgUri = "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg",
                    Type = ResourceType.FORUM,
                    OfferId = 1
                },
                new Resource
                {
                    Id = 3,
                    Title = "Lives",
                    Description = "Lives exclusivas para a turma",
                    Position = 3,
                    imgUri = "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg",
                    Type = ResourceType.LESSON_ONLY,
                    OfferId = 1
                }
            );

            builder.Entity<Section>().HasData(
                new Section
                {
                    Id = 1,
                    Title = "Capítulo 1",
                    Description = "Neste capítulo vamos começar",
                    Position = 1,
                    ImgUri = "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg",
                    ResourceId = 1,
                    PreRequisiteId = null
                },
                new Section
                {
                    Id = 2,
                    Title = "Capítulo 2",
                    Description = "Neste capítulo vamos continuar",
                    Position = 2,
                    ImgUri = "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg",
                    ResourceId = 1,
                    PreRequisiteId = 1
                },
                new Section
                {
                    Id = 3,
                    Title = "Capítulo 3",
                    Description = "Neste capítulo vamos finalizar",
                    Position = 3,
                    ImgUri = "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg",
                    ResourceId = 1,
                    PreRequisiteId = 2
                }
            );

            builder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    OfferId = 1,
                    UserId = "3b01910b-4e21-4cf3-a859-9a79261d0385",
                    EnrollMoment = DateTime.Parse("2020-11-20 13:00:00"),
                    RefundMoment = null,
                    Available = true,
                    OnlyUpdate = false
                },
                new Enrollment
                {
                    OfferId = 2,
                    UserId = "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7",
                    EnrollMoment = DateTime.Parse("2020-11-20 13:00:00"),
                    RefundMoment = null,
                    Available = true,
                    OnlyUpdate = false
                }
            );

            builder.Entity<Content>().HasData(
                new Content
                {
                    Id = 1,
                    Title = "Aula 1 do capítulo 1",
                    Position = 1,
                    SectionId = 1,
                    TextContent = "Material de apoio: abc",
                    VideoUri = "https://www.youtube.com/watch?v=sqbqoR-lMf8"
                },
                new Content
                {
                    Id = 2,
                    Title = "Aula 2 do capítulo 1",
                    Position = 2,
                    SectionId = 1,
                    TextContent = string.Empty,
                    VideoUri = "https://www.youtube.com/watch?v=sqbqoR-lMf8"
                },
                new Content
                {
                    Id = 3,
                    Title = "Aula 3 do capítulo 1",
                    Position = 3,
                    SectionId = 1,
                    TextContent = string.Empty,
                    VideoUri = "https://www.youtube.com/watch?v=sqbqoR-lMf8"
                }
            );

            builder.Entity<Task>().HasData(
                new Task
                {
                    Id = 4,
                    Title = "Tarefa do capítulo 1",
                    Position = 4,
                    SectionId = 1,
                    Description = "Fazer um trabalho legal",
                    QuestionCount = 5,
                    ApprovalCount = 4,
                    Weight = 1.0,
                    DueMoment = DateTime.Parse("2020-11-25 13:00:00")
                }
            );

            builder.Entity<Notification>().HasData(
                new Notification
                {
                    Id = 1,
                    Text = "Primeiro feedback de tarefa: favor revisar",
                    Moment = DateTime.Parse("2020-12-10 13:00:00"),
                    Read = true,
                    Route = "/offers/1/resource/1/sections/1",
                    UserId = "3b01910b-4e21-4cf3-a859-9a79261d0385"
                },
                new Notification
                {
                    Id = 2,
                    Text = "Segundo feedback: favor revisar",
                    Moment = DateTime.Parse("2020-12-12 13:00:00"),
                    Read = true,
                    Route = "/offers/1/resource/1/sections/1",
                    UserId = "3b01910b-4e21-4cf3-a859-9a79261d0385"
                },
                new Notification
                {
                    Id = 3,
                    Text = "Terceiro feedback: favor revisar",
                    Moment = DateTime.Parse("2020-12-14 13:00:00"),
                    Read = true,
                    Route = "/offers/1/resource/1/sections/1",
                    UserId = "3b01910b-4e21-4cf3-a859-9a79261d0385"
                }
            );

            builder.Entity<Deliver>().HasData(
                new Deliver
                {
                    Id = 1,
                    Uri = "https://github.com/devsuperior/bds-dslearn",
                    Moment = DateTime.Parse("2020-12-10 10:00:00"),
                    Status = DeliverStatus.PENDING,
                    LessonId = 4,
                    Feedback = null,
                    UserId = "3b01910b-4e21-4cf3-a859-9a79261d0385",
                    OfferId = 1 // Ensure that this value corresponds to an existing Enrollment entity
                }
            );

            builder.Entity<Topic>().HasData(
                new Topic
                {
                    Id = 1,
                    Title = "Título do tópico 1",
                    Body = "Corpo do tópico 1",
                    Moment = DateTime.Parse("2020-12-12 13:00:00"),
                    AuthorId = "3b01910b-4e21-4cf3-a859-9a79261d0385",
                    OfferId = 1,
                    LessonId = 1
                },
                new Topic
                {
                    Id = 2,
                    Title = "Título do tópico 2",
                    Body = "Corpo do tópico 2",
                    Moment = DateTime.Parse("2020-12-13 13:00:00"),
                    AuthorId = "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7",
                    OfferId = 1,
                    LessonId = 1
                },
                new Topic
                {
                    Id = 3,
                    Title = "Título do tópico 3",
                    Body = "Corpo do tópico 3",
                    Moment = DateTime.Parse("2020-12-14 13:00:00"),
                    AuthorId = "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7",
                    OfferId = 1,
                    LessonId = 1
                },
                new Topic
                {
                    Id = 4,
                    Title = "Título do tópico 4",
                    Body = "Corpo do tópico 4",
                    Moment = DateTime.Parse("2020-12-15 13:00:00"),
                    AuthorId = "3b01910b-4e21-4cf3-a859-9a79261d0385",
                    OfferId = 1,
                    LessonId = 2
                },
                new Topic
                {
                    Id = 5,
                    Title = "Título do tópico 5",
                    Body = "Corpo do tópico 5",
                    Moment = DateTime.Parse("2020-12-16 13:00:00"),
                    AuthorId = "3b01910b-4e21-4cf3-a859-9a79261d0385",
                    OfferId = 1,
                    LessonId = 2
                },
                new Topic
                {
                    Id = 6,
                    Title = "Título do tópico 6",
                    Body = "Corpo do tópico 6",
                    Moment = DateTime.Parse("2020-12-17 13:00:00"),
                    AuthorId = "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7",
                    OfferId = 1,
                    LessonId = 3
                }
            );

            builder.Entity<Reply>().HasData(
                new Reply
                {
                    Id = 1,
                    Body = "Tente reiniciar o computador",
                    Moment = DateTime.Parse("2020-12-15 13:00:00"),
                    TopicId = 1,
                    AuthorId = "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7"
                },
                new Reply
                {
                    Id = 2,
                    Body = "Deu certo, valeu!",
                    Moment = DateTime.Parse("2020-12-20 13:00:00"),
                    TopicId = 1,
                    AuthorId = "3b01910b-4e21-4cf3-a859-9a79261d0385"
                }
            );
        }
    }
}
