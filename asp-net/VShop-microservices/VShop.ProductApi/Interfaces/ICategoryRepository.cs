using VShop.ProductApi.DTOs.CategoryDTOs;

namespace VShop.ProductApi.Interfaces
{
    public interface ICategoryRepository
    {

        Task<IEnumerable<CategoryDTO>> FindAll();
        Task<IEnumerable<CategoryDTO>> FindAllCategoriesWithProducts();
        Task<CategoryDTO> FindById(int Id);
        Task<CategoryDTO> Insert(CategoryInsertDTO categoryInsertDTO);
        Task<CategoryDTO> Update(CategoryInsertDTO categoryDTO, int Id);
        Task<CategoryDTO> DeleteById(int Id);

    }
}
