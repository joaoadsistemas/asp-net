using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using System.Threading.Tasks;

namespace DSLearn.Interfaces
{
    public interface IContentRepository
    {
        Task<IEnumerable<ContentDTO>> FindAllAsync(PageQueryParams pageQueryParams);
        Task<ContentDTO> FindByIdAsync(int id);
        ContentDTO Insert(ContentInsertDTO contentInsertDTO);
        ContentDTO Update(ContentInsertDTO contentInsertDTO, int id);
        bool Delete(int id);
    }
}
