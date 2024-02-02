using ApiCatalogo.Dtos;

namespace ApiCatalogo.Repositories;

public interface ProductRepository
{

    Task<List<ProductDTO>> FindAllProducts();
    Task<ProductDTO> FindProductById(long id);
    Task<ProductDTO> InsertProduct(ProductInsertDTO dto);
    void UpdateProduct(ProductInsertDTO dto, long id);
    bool DeleteProduct(long id);
}