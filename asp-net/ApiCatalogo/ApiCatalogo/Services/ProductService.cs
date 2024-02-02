using ApiCatalogo.Dtos;
using ApiCatalogo.Entities;
using ApiCatalogo.Repositories;
using ApiCatalogo.Repositories.db;

namespace ApiCatalogo.Services;

public class ProductService : ProductRepository
{

    private readonly SystemDbContext _dbContext;

    public ProductService(SystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<ProductDTO>> FindAllProducts()
    {
        List<Product> result = _dbContext.Products.ToList();
        return result.AsEnumerable().Select(p => new ProductDTO(p)).ToList();
    }

    public async Task<ProductDTO> FindProductById(int id)
    {
        throw new NotImplementedException();
    }

    public void InsertProduct(ProductInsertDTO dto)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(ProductInsertDTO dto, int id)
    {
        throw new NotImplementedException();
    }

    public bool DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}