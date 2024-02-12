using AutoMapper;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using DSLearn.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        public SystemDbContext _dbContext;
        private IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private INotificationRepository _notificationRepository;



        public UnitOfWork(SystemDbContext dbContext, UserManager<User> userManager, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }


        public IUserRepository UserRepository { get { return _userRepository = _userRepository ?? new UserService(_dbContext, _userManager); } }
        public INotificationRepository NotificationRepository { get { return _notificationRepository = _notificationRepository ?? new NotificationService(_dbContext, _mapper);} }

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
