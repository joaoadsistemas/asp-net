using eCommerce.API.Dtos;

namespace eCommerce.API.Repositories;

public interface IUserRepository
{
    Task<List<UserDTO>> GetAll();
    Task<UserDTO> GetById(int id);
    void Insert(UserInsertDTO dto);
    void Update(UserInsertDTO dto, int id);
    void Delete(int id);
}