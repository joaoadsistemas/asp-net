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
        Task<IEnumerable<UserRolesDTO>> FindAllUserRolesAsync(PageQueryParams pageQueryParams);
        Task<IEnumerable<UserAllInformationsDTO>> FindAllUserAllInformationsAsync(PageQueryParams pageQueryParams);
        void AddLikeToReply(int replyId, string userId);
        void AddLikeToTopic(int topicId, string userId);
        Task<UserAllInformationsDTO> FindByIdUserAllInformationsAsync(string id);
        Task<UserDTO> FindByIdAsync(string id);
        UserDTO Update(RegisterUserDTO registerUserDTO, string id);
        bool Delete(string id);
    }
}
