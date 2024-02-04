using ApiCatalogo.Dtos;

namespace ApiCatalogo.Repositories;

public interface ICategoryRepository
{

    IEnumerable<CategoryDTO> FindAllCategories();
    CategoryDTO FindCategoryById(long id);
    CategoryDTO InsertCategory(CategoryInsertDTO dto);
    CategoryDTO UpdateCategory(CategoryInsertDTO dto, long id);
    bool DeleteCategory(long id);
}