using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using System.Threading.Tasks;

namespace DSLearn.Interfaces
{
    public interface ISectionRepository
    {
        Task<IEnumerable<SectionDTO>> FindAllAsync(PageQueryParams pageQueryParams);
        Task<SectionDTO> FindByIdAsync(int id);
        SectionDTO Insert(SectionInsertDTO sectionInsertDTO);
        SectionDTO Update(SectionInsertDTO sectionInsertDTO, int id);
        bool Delete(int id);
    }
}
