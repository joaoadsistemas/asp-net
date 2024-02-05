using ApiCatalogo.Dtos;
using ApiCatalogo.Entities;
using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using ApiCatalogo.Repositories.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ApiCatalogo.Services;

public class ProductService : IProductRepository
{

    private readonly SystemDbContext _dbContext;

    public ProductService(SystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<ProductDTO>> FindAllProductsAsync(PageQueryParams pageQueryParams)
    {
        // utilizando queryparams para pesquisar por nome do produto e paginando tambem
        List<Product> result = await _dbContext.Products.Where(p => p.Name.Contains(pageQueryParams.Name))
            .OrderBy(p => p.Name)
            .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
            .Take(pageQueryParams.PageSize)
            .AsNoTracking().ToListAsync();
        return result.AsEnumerable().Select(p => new ProductDTO(p)).ToList();

    }
    public async Task<ProductDTO> FindProductByIdAsync(long id)
    {
        Product result = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception("Resource not found");
        return new ProductDTO(result);
    }

    public ProductDTO InsertProduct(ProductInsertDTO dto)
    {
        Product entity = new Product();
        copyDtoToEntity(dto, entity);
        _dbContext.Add(entity);
        return new ProductDTO(entity);
    }

    public ProductDTO UpdateProduct(ProductInsertDTO dto, long id)
    {
        Product entity = _dbContext.Products.Find(id) ?? throw new Exception("Resource not found");
        copyDtoToEntity(dto, entity);
        return new ProductDTO(entity);
    }

    public bool DeleteProduct(long id)
    {
        Product entity = _dbContext.Products.Find(id) ?? throw new Exception("Resource not found");
        _dbContext.Remove(entity);
        return true;
    }
    
    
    private void copyDtoToEntity(ProductInsertDTO dto, Product entity)
    {
        entity.Name = dto.Name;
        entity.Description = dto.Description;
        entity.Price = dto.Price;
        entity.ImgUrl = dto.ImgUrl;
        entity.Stock = dto.Stock;
        entity.RegisterData = DateTimeOffset.Now;

        Category category = _dbContext.Categories.Find(dto.CategoryId) ?? throw new Exception();
        entity.CategoryId = category.Id;
    }
}