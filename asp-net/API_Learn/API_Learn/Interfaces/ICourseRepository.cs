using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using System.Threading.Tasks;

namespace DSLearn.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseDTO>> FindAllAsync(PageQueryParams pageQueryParams);
        Task<CourseDTO> FindByIdAsync(int id);
        CourseDTO Insert(CourseInsertDTO courseInsertDTO);
        CourseDTO Update(CourseInsertDTO courseInsertDTO, int id);
        bool Delete(int id);
    }
}
