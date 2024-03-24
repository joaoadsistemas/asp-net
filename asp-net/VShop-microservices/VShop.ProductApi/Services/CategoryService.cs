using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.DTOs.CategoryDTOs;
using VShop.ProductApi.Entities;
using VShop.ProductApi.Interfaces;

namespace VShop.ProductApi.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly SystemDbContext _dbContext;

        public CategoryService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryDTO>> FindAll()
        {
            List<Category> entities = await _dbContext.Categories
                .ToListAsync();
            return entities.Select(c => new CategoryDTO(c));
        }

        public async Task<IEnumerable<CategoryDTO>> FindAllCategoriesWithProducts()
        {
            List<Category> entities = await _dbContext.Categories.Include(c => c.Products)
                .ToListAsync();
            return entities.Select(c => new CategoryDTO(c));
        }

        public async Task<CategoryDTO> FindById(int Id)
        {
            Category entity = await _dbContext.Categories.Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == Id) ?? throw new ArgumentException("Resource not found");
            return new CategoryDTO(entity);
        }

        public async Task<CategoryDTO> Insert(CategoryInsertDTO categoryInsertDTO)
        {
            
            Category entity = new Category();
            copyDTOToEntity(categoryInsertDTO, entity);
            await _dbContext.Categories.AddAsync(entity);
            return new CategoryDTO(entity);
        }

       

        public async Task<CategoryDTO> Update(CategoryInsertDTO categoryInsertDTO, int Id)
        {
            Category entity = await _dbContext.Categories.Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == Id) ?? throw new ArgumentException("Resource not found");
            copyDTOToEntity(categoryInsertDTO, entity);
            _dbContext.Categories.Update(entity);
            return new CategoryDTO(entity);
        }

        public async Task<CategoryDTO> DeleteById(int Id)
        {
            Category entity = await _dbContext.Categories.Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == Id) ?? throw new ArgumentException("Resource not found");
            _dbContext.Categories.Remove(entity);
            return new CategoryDTO(entity);
        }



        private void copyDTOToEntity(CategoryInsertDTO categoryInsertDTO, Category entity)
        {
            entity.Name = categoryInsertDTO.Name;
        }
    }
}
