using DSLearn.Interfaces;

namespace ApiCatalogo.Repositories
{
    public interface IUnitOfWork
    {

        IUserRepository UserRepository { get; }
        INotificationRepository NotificationRepository { get; }
        ICourseRepository CourseRepository { get; }
        IOfferRepository OfferRepository { get; }
        IResourceRepository ResourceRepository { get; }
        ISectionRepository SectionRepository { get; }
        ITaskRepository TaskRepository { get; } 
        IContentRepository ContentRepository { get; }
        IDeliverRepository DeliverRepository { get; }
        IEnrollmentRepository EnrollmentRepository { get; }

        Task CommitAsync();

    }
}
