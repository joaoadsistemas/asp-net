using ApiCatalogo.Dtos;

namespace ApiCatalogo.Repositories;

public interface IProductRepository
{

    IEnumerable<ProductDTO> FindAllProducts(string name);
    ProductDTO FindProductById(long id);
    ProductDTO InsertProduct(ProductInsertDTO dto);
    ProductDTO UpdateProduct(ProductInsertDTO dto, long id);
    bool DeleteProduct(long id);
}