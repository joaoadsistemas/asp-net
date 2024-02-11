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
        public SystemDbContext _dbContext;
        private IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;



        public UnitOfWork(SystemDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }


        public IUserRepository UserRepository { get { return _userRepository = _userRepository ?? new UserService(_dbContext, _userManager); } }

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
