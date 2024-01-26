using DSCommerce.Dto;
using DSCommerce.Repositories;
using DSCommerce.Repositories.db;

namespace DSCommerce.Services
{
    public class ProductService : ProductRepository
    {
        private readonly SystemDbContext _dbContext;

        public ProductService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Task<List<ProductDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> Insert(ProductDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> Update(ProductDTO dto, long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
