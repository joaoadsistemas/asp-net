using System.Security.AccessControl;
using DSCommerce.Dto;
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

        public Task<List<CategoryDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> Insert(CategoryDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> Update(CategoryDTO dto, long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
