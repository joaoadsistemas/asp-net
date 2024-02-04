using ApiCatalogo.Dtos;
using ApiCatalogo.Entities;
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
    
    public IEnumerable<ProductDTO> FindAllProducts(string name)
    {
        // utilizando queryparams para pesquisar por nome do produto tambem
        List<Product> result = _dbContext.Products.Where(p => p.Name.Contains(name)).AsNoTracking().ToList();
        return result.AsEnumerable().Select(p => new ProductDTO(p)).ToList();

    }
    public ProductDTO FindProductById(long id)
    {
        Product result = _dbContext.Products.AsNoTracking().FirstOrDefault(p => p.Id == id) ?? throw new Exception("Resource not found");
        return new ProductDTO(result);
    }

    public ProductDTO InsertProduct(ProductInsertDTO dto)
    {
        Product entity = new Product();
        copyDtoToEntity(dto, entity);
        _dbContext.Add(entity);
        _dbContext.SaveChanges();
        return new ProductDTO(entity);
    }

    public ProductDTO UpdateProduct(ProductInsertDTO dto, long id)
    {
        Product entity = _dbContext.Products.Find(id) ?? throw new Exception("Resource not found");
        copyDtoToEntity(dto, entity);
        _dbContext.SaveChanges();
        return new ProductDTO(entity);
    }

    public bool DeleteProduct(long id)
    {
        Product entity = _dbContext.Products.Find(id) ?? throw new Exception("Resource not found");
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

        Category category = _dbContext.Categories.Find(dto.CategoryId) ?? throw new Exception();
        entity.CategoryId = category.Id;
    }
}