using DSCommerce.Dto;

namespace DSCommerce.Repositories
{
    public interface UserRepository
    {

        Task<List<UserDTO>> FindAll();
        Task<UserDTO> FindById(long id);
        Task<UserSimpleDTO> Insert(UserSimpleDTO dto);
        Task<UserSimpleDTO> Update(UserSimpleDTO dto, long id);
        Task<bool> DeleteById(long id);

    }
}
