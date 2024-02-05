using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;

namespace ApiCatalogo.Repositories;

public interface IProductRepository
{

    IEnumerable<ProductDTO> FindAllProducts(PageQueryParams pageQueryParams);
    ProductDTO FindProductById(long id);
    ProductDTO InsertProduct(ProductInsertDTO dto);
    ProductDTO UpdateProduct(ProductInsertDTO dto, long id);
    bool DeleteProduct(long id);
}