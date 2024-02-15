using ApiCatalogo.Dtos;
using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using System.Threading.Tasks;

namespace DSLearn.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskDTO>> FindAllAsync(PageQueryParams pageQueryParams);
        Task<TaskDTO> FindByIdAsync(int id);
        TaskDTO Insert(TaskInsertDTO taskInsertDTO);
        TaskDTO Update(TaskInsertDTO taskInsertDTO, int id);
        bool Delete(int id);
    }
}
