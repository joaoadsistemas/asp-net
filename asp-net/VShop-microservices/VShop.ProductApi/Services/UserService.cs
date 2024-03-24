using VShop.ProductApi.Context;
using VShop.ProductApi.DTOs.UserDTOs;
using VShop.ProductApi.Interfaces;

namespace VShop.ProductApi.Services
{
    public class UserService : IUserRepository
    {
        private readonly SystemDbContext _dbContext;

        public UserService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<UserDTO>> FindAllUser()
        {
            throw new NotImplementedException();
        }
    }
}
