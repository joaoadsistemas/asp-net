using ApiCatalogo.Repositories.db;
using ApiCatalogo.Services;

namespace ApiCatalogo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository _productRepository;

        private ICategoryRepository _categoryRepository;
        public SystemDbContext _dbContext;

        public UnitOfWork(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IProductRepository ProductRepository { get { return _productRepository = _productRepository ?? new ProductService(_dbContext); } }
        public ICategoryRepository CategoryRepository { get { return _categoryRepository = _categoryRepository ?? new CategoryService(_dbContext); } }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Dispose()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
