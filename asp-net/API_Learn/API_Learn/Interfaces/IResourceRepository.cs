using ApiCatalogo.Pagination;
using DSLearn.Dtos;

namespace DSLearn.Interfaces
{
    public interface IResourceRepository
    {
        Task<IEnumerable<ResourceDTO>> FindAllAsync(PageQueryParams pageQueryParams);
        Task<ResourceDTO> FindByIdAsync(int id);
        ResourceDTO Insert(ResourceInsertDTO resourceInsertDTO);
        ResourceDTO Update(ResourceInsertDTO resourceInsertDTO, int id);
        bool Delete(int id);
    }
}
