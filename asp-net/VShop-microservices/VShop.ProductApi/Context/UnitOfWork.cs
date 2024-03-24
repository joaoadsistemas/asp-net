using BackEndASP.Interfaces;
using VShop.ProductApi.Context;
using VShop.ProductApi.Interfaces;
using VShop.ProductApi.Services;

public class UnitOfWork : IUnitOfWorkRepository
{
    private IUserRepository _userRepository;
    private ICategoryRepository _categoryRepository;

    private SystemDbContext _dbContext;

    public UnitOfWork(SystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IUserRepository UserRepository
    { get { return _userRepository = _userRepository ?? new UserService(_dbContext); } }

    public ICategoryRepository CategoryRepository { get { return _categoryRepository = _categoryRepository ?? new CategoryService(_dbContext)} }

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task Dispose()
    {
        await _dbContext.DisposeAsync();
    }
}