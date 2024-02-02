using ApiCatalogo.Dtos;
using ApiCatalogo.Repositories;
using ApiCatalogo.Repositories.db;

namespace ApiCatalogo.Services;

public class CategoryService : CategoryRepository
{

    private readonly SystemDbContext _dbContext;

    public CategoryService(SystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<CategoryDTO>> FindAllProducts()
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryDTO> FindProductById(int id)
    {
        throw new NotImplementedException();
    }

    public void InsertProduct(CategoryInsertDTO dto)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(CategoryInsertDTO dto, int id)
    {
        throw new NotImplementedException();
    }

    public bool  DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}