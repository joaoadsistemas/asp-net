using VShop.ProductApi.Context;
using VShop.ProductApi.DTOs.CategoryDTOs;
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

        public Task<IEnumerable<CategoryDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDTO>> FindAllCategoriesWithProducts()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> Insert(CategoryInsertDTO categoryInsertDTO)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> Update(CategoryInsertDTO categoryInsertDTO, int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
