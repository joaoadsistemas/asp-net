using eCommerce.API.Dtos;

namespace eCommerce.API.Repositories;

public class UserRepository : IUserRepository
{
    public Task<List<UserDTO>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Insert(UserInsertDTO dto)
    {
        throw new NotImplementedException();
    }

    public void Update(UserInsertDTO dto, int id)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}