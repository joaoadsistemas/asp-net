using ApiCatalogo.Dtos;

namespace ApiCatalogo.Repositories;

public interface CategoryRepository
{

    Task<List<CategoryDTO>> FindAllCategories();
    Task<CategoryDTO> FindCategoryById(long id);
    Task<CategoryDTO> InsertCategory(CategoryInsertDTO dto);
    void UpdateCategory(CategoryInsertDTO dto, long id);
    bool DeleteCategory(long id);
}