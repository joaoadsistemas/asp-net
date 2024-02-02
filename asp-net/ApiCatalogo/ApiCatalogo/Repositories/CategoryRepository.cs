using ApiCatalogo.Dtos;

namespace ApiCatalogo.Repositories;

public interface CategoryRepository
{

    Task<List<CategoryDTO>> FindAllProducts();
    Task<CategoryDTO> FindProductById(int id);
    void InsertProduct(CategoryInsertDTO dto);
    void UpdateProduct(CategoryInsertDTO dto, int id);
    bool DeleteProduct(int id);
}