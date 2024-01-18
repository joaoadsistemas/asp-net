using one_to_many.Dto;
using one_to_many.Repositories;
using one_to_many.Repositories.db;
using User = relation_one_to_many.Entities.User;

namespace one_to_many.Services
{
    public class UserService : UserRepository
    {

        private readonly SystemDbContext _context;

        public UserService(SystemDbContext context)
        {
            _context = context;
        }



        public Task<List<UserDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> FindById(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id) ?? throw new Exception("Resource not found");
            return new UserDTO(user);
        }

        public Task<UserDTO> Insert(UserDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Update(UserDTO dto, int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
