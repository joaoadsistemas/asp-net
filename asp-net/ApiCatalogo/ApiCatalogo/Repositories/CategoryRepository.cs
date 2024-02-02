using ApiCatalogo.Dtos;

namespace ApiCatalogo.Repositories;

public interface CategoryRepository
{

    Task<List<CategoryDTO>> FindAllCategories();
    Task<CategoryDTO> FindCategoryById(int id);
    void InsertCategory(CategoryInsertDTO dto);
    void UpdateCategory(CategoryInsertDTO dto, int id);
    bool DeleteCategory(int id);
}