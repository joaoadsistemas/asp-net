using System.Security.AccessControl;
using DSCommerce.Dto;
using DSCommerce.Entities;
using DSCommerce.Repositories;
using DSCommerce.Repositories.db;

namespace DSCommerce.Services
{
    public class CategoryService : CategoryRepository
    {

        private readonly SystemDbContext _dbContext;

        public CategoryService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategoryDTO>> FindAll()
        {
            List<Category> categories = _dbContext.Categories.ToList();
            return categories.AsEnumerable().Select(c => new CategoryDTO(c)).ToList();
        }

        public async Task<CategoryDTO> FindById(long id)
        {
            Category category = _dbContext.Categories.Find(id) ?? throw new Exception("Resource not found");
            return new CategoryDTO(category);
        }

        public async Task<CategoryInsertDTO> Insert(CategoryInsertDTO dto)
        {
            Category entity = new Category();
            copyDtoToEntity(dto, entity);
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return new CategoryInsertDTO(entity);
        }

       

        public async Task<CategoryDTO> Update(CategoryInsertDTO dto, long id)
        {
            Category entity = _dbContext.Categories.Find(id) ?? throw new Exception("Resource not found");
            copyDtoToEntity(dto, entity);
            _dbContext.SaveChanges();
            return new CategoryDTO(entity);

        }

        public async Task<bool> DeleteById(long id)
        {
            Category entity = _dbContext.Categories.Find(id) ?? throw new Exception("Resource not found");
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
            return true;

        }


        private void copyDtoToEntity(CategoryInsertDTO dto, Category entity)
        {
            entity.name = dto.Name;
        }
    }
}
