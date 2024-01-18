using one_to_many.Dto;

namespace one_to_many.Repositories
{
    public interface UserRepository
    {
        Task<List<UserDTO>> FindAll();
        Task<UserDTO> FindById(int id);
        Task<UserDTO> Insert(UserDTO dto);
        Task<UserDTO> Update(UserDTO dto, int id);
        Task<UserDTO> DeleteById(int id);
    }
}
