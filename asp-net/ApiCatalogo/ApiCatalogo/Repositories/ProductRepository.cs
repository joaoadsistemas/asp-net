using ApiCatalogo.Dtos;

namespace ApiCatalogo.Repositories;

public interface ProductRepository
{

    Task<List<ProductDTO>> FindAllProducts();
    Task<ProductDTO> FindProductById(int id);
    void InsertProduct(ProductInsertDTO dto);
    void UpdateProduct(ProductInsertDTO dto, int id);
    bool DeleteProduct(int id);
}