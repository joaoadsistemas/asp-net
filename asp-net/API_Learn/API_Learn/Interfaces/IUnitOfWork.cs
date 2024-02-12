﻿using DSLearn.Interfaces;

namespace ApiCatalogo.Repositories
{
    public interface IUnitOfWork
    {

        IUserRepository UserRepository { get; }
        INotificationRepository NotificationRepository { get; }
        ICourseRepository CourseRepository { get; }

        Task CommitAsync();

    }
}
