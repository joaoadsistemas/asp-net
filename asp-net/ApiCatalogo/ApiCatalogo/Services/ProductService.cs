using ApiCatalogo.Dtos;
using ApiCatalogo.Entities;
using ApiCatalogo.Repositories;
using ApiCatalogo.Repositories.db;
using Microsoft.EntityFrameworkCore;

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
        List<Product> result = _dbContext.Products.AsNoTracking().ToList();
        return result.AsEnumerable().Select(p => new ProductDTO(p)).ToList();
    }

    public async Task<ProductDTO> FindProductById(long id)
    {
        Product result = _dbContext.Products.AsNoTracking().FirstOrDefault(p => p.Id == id) ?? throw new Exception("Resource not found");
        return new ProductDTO(result);
    }

    public async Task<ProductDTO> InsertProduct(ProductInsertDTO dto)
    {
        Product entity = new Product();
        copyDtoToEntity(dto, entity);
        _dbContext.Add(entity);
        _dbContext.SaveChanges();
        return new ProductDTO(entity);
    }

    public void UpdateProduct(ProductInsertDTO dto, long id)
    {
        Product entity = _dbContext.Products.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Resource not found");
        copyDtoToEntity(dto, entity);
        _dbContext.SaveChanges();
    }

    public bool DeleteProduct(long id)
    {
        Product entity = _dbContext.Products.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Resource not found");
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();
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

        Category category = _dbContext.Categories.FirstOrDefault(c => c.Id == dto.CategoryId) ?? throw new Exception();
        entity.CategoryId = category.Id;
    }
}