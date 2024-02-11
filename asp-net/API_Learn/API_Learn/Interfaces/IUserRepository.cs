using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using System.Threading.Tasks;

namespace DSLearn.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> FindAllAsync(PageQueryParams pageQueryParams);
        Task<UserDTO> FindByIdAsync(string id);
        Task<bool> UpdateAsync(RegisterUserDTO registerUserDTO, string id);
        Task<bool> DeleteAsync(string id);
    }
}
