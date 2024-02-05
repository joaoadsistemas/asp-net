using ApiCatalogo.Dtos;

namespace ApiCatalogo.Repositories;

public interface ICategoryRepository
{

    Task<IEnumerable<CategoryDTO>> FindAllCategoriesAsync();
    Task<CategoryDTO> FindCategoryByIdAsync(long id);
    CategoryDTO InsertCategory(CategoryInsertDTO dto);
    CategoryDTO UpdateCategory(CategoryInsertDTO dto, long id);
    bool DeleteCategory(long id);
}