using ApiCatalogo.Dtos;
using ApiCatalogo.Entities;
using ApiCatalogo.Repositories;
using ApiCatalogo.Repositories.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ApiCatalogo.Services;

public class CategoryService : ICategoryRepository
{

    private readonly SystemDbContext _dbContext;

    public CategoryService(SystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public IEnumerable<CategoryDTO> FindAllCategories()
    {
        List<Category> entity = _dbContext.Categories
            .Include(c => c.Products).AsNoTracking().ToList();
        return entity.AsEnumerable().Select(c => new CategoryDTO(c)).ToList();

    }

    public CategoryDTO FindCategoryById(long id)
    {
        Category entity = _dbContext.Categories
            .Include(c => c.Products)
            .AsNoTracking()
            .SingleOrDefault(c => c.Id == id) ?? throw new Exception("Resource not found");
        return new CategoryDTO(entity);
    }

    public CategoryDTO InsertCategory(CategoryInsertDTO dto)
    {
        Category entity = new Category();
        copyDtoToEntity(dto,entity);
        _dbContext.Add(entity);
        _dbContext.SaveChanges();
        return new CategoryDTO(entity);
    }


    public CategoryDTO UpdateCategory(CategoryInsertDTO dto, long id)
    {
        Category entity = _dbContext.Categories.Find(id) ?? throw new Exception("Resource not found");
        copyDtoToEntity(dto, entity);
        _dbContext.SaveChanges();
        return new CategoryDTO(entity);
    }

    public bool DeleteCategory(long id)
    {
        Category entity = _dbContext.Categories.Find(id) ?? throw new Exception("Resource not found");
        _dbContext.Remove(entity);
        return true;
    }
    
    private void copyDtoToEntity(CategoryInsertDTO dto, Category entity)
    {
        entity.Name = dto.Name;
        entity.ImgUrl = dto.ImgUrl;
        
        
    }
}