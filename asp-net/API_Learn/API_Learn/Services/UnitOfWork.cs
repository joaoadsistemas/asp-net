using AutoMapper;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using DSLearn.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace ApiCatalogo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public SystemDbContext _dbContext;
        private IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private INotificationRepository _notificationRepository;
        private ICourseRepository _courseRepository;
        private IOfferRepository _offerRepository;
        private IResourceRepository _resourceRepository;
        private ISectionRepository _sectionRepository;
        private ITaskRepository _taskRepository;
        private IContentRepository _contentRepository;
        private IDeliverRepository _deliverRepository;
        private IEnrollmentRepository _enrollmentRepository;
        private ITopicRepository _topicRepository;
        private IReplyRepository _replyRepository;


        public UnitOfWork(SystemDbContext dbContext, UserManager<User> userManager, IContentRepository contentRepository)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _contentRepository = contentRepository;
        }


        public IUserRepository UserRepository { get { return _userRepository = _userRepository ?? new UserService(_dbContext, _userManager); } }
        public INotificationRepository NotificationRepository { get { return _notificationRepository = _notificationRepository ?? new NotificationService(_dbContext);} }
        public ICourseRepository CourseRepository { get { return _courseRepository = _courseRepository ?? new CourseService(_dbContext);} }
        public IOfferRepository OfferRepository { get { return _offerRepository = _offerRepository ?? new OfferService(_dbContext); } }
        public IResourceRepository ResourceRepository { get { return _resourceRepository = _resourceRepository ?? new ResourceService(_dbContext); } }
        public ISectionRepository SectionRepository { get { return _sectionRepository = _sectionRepository ?? new SectionService(_dbContext); } }
        public ITaskRepository TaskRepository { get { return _taskRepository = _taskRepository ?? new TaskService(_dbContext); } }
        public IContentRepository ContentRepository { get { return _contentRepository = _contentRepository ?? new ContentService(_dbContext); } }
        public IDeliverRepository DeliverRepository { get { return _deliverRepository = _deliverRepository ?? new DeliverService(_dbContext); } }
        public IEnrollmentRepository EnrollmentRepository{ get { return _enrollmentRepository = _enrollmentRepository ?? new EnrollmentService(_dbContext); } }
        public ITopicRepository TopicRepository { get { return _topicRepository = _topicRepository ?? new TopicService(_dbContext); } }
        public IReplyRepository ReplyRepository { get { return _replyRepository = _replyRepository ?? new ReplyService(_dbContext); } }

        public async System.Threading.Tasks.Task CommitAsync()
        {
        
          await _dbContext.SaveChangesAsync();
   
         
        }

        public async System.Threading.Tasks.Task Dispose()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
