using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using System.Threading.Tasks;

namespace DSLearn.Interfaces
{
    public interface INotificationRepository
    {
        Task<IEnumerable<NotificationDTO>> FindAllAsync(PageQueryParams pageQueryParams);
        Task<NotificationDTO> FindByIdAsync(int id);
        Task<IEnumerable<NotificationDTO>> FindByUserAsync(string id);
        NotificationDTO Insert(NotificationInsertDTO notificationInsertDTO);
        NotificationDTO Update(NotificationInsertDTO notificationInsertDTO, int id);
        bool Delete(int id);
    }
}
