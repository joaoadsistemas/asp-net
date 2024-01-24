using DSCommerce.Dto;
using DSCommerce.Repositories;

namespace DSCommerce.Services
{
    public class UserService : UserRepository
    {
        public Task<List<UserDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Insert(UserDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Update(UserDTO dto, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
