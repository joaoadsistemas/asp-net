using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;

namespace ApiCatalogo.Repositories;

public interface IProductRepository
{

    Task<IEnumerable<ProductDTO>> FindAllProductsAsync(PageQueryParams pageQueryParams);
    Task<ProductDTO> FindProductByIdAsync(long id);
    ProductDTO InsertProduct(ProductInsertDTO dto);
    ProductDTO UpdateProduct(ProductInsertDTO dto, long id);
    bool DeleteProduct(long id);
}