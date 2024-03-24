using VShop.ProductApi.DTOs.UserDTOs;

namespace VShop.ProductApi.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> FindAllUser();
    }
}
