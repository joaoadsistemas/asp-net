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



        public UnitOfWork(SystemDbContext dbContext, UserManager<User> userManager, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }


        public IUserRepository UserRepository { get { return _userRepository = _userRepository ?? new UserService(_dbContext, _userManager); } }
        public INotificationRepository NotificationRepository { get { return _notificationRepository = _notificationRepository ?? new NotificationService(_dbContext);} }
        public ICourseRepository CourseRepository { get { return _courseRepository = _courseRepository ?? new CourseService(_dbContext);} }
        public IOfferRepository OfferRepository { get { return _offerRepository = _offerRepository ?? new OfferService(_dbContext); } }
        public IResourceRepository ResourceRepository { get { return _resourceRepository = _resourceRepository ?? new ResourceService(_dbContext); } }
        public ISectionRepository SectionRepository { get { return _sectionRepository = _sectionRepository ?? new SectionService(_dbContext); } }

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
