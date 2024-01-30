using DSCommerce.Dto;

namespace DSCommerce.Repositories
{
    public interface UserRepository
    {

        Task<List<UserDTO>> FindAll();
        Task<UserDTO> FindById(long id);
        Task<UserInsertDTO> Insert(UserInsertDTO dto);
        Task<UserInsertDTO> Update(UserInsertDTO dto, long id);
        Task<bool> DeleteById(long id);

    }
}
