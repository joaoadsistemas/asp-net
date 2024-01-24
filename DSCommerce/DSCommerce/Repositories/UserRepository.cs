using DSCommerce.Dto;

namespace DSCommerce.Repositories
{
    public interface UserRepository
    {

        Task<List<UserDTO>> FindAll();
        Task<UserDTO> FindById(int id);
        Task<UserDTO> Insert(UserDTO dto);
        Task<UserDTO> Update(UserDTO dto, int id);
        Task<bool> DeleteById(int id);

    }
}
