using VShop.ProductApi.DTOs.CategoryDTOs;

namespace VShop.ProductApi.Interfaces
{
    public interface ICategoryRepository
    {

        Task<IEnumerable<CategoryDTO>> FindAll();
        Task<IEnumerable<CategoryDTO>> FindAllCategoriesWithProducts();
        Task<CategoryDTO> FindById(int id);
        Task<CategoryDTO> Insert(CategoryInsertDTO categoryInsertDTO);
        Task<CategoryDTO> Update(CategoryInsertDTO categoryDTO, int id);
        Task<CategoryDTO> DeleteById(int id);

    }
}
