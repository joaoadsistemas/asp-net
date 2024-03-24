using VShop.ProductApi.Interfaces;

namespace BackEndASP.Interfaces
{
    public interface IUnitOfWorkRepository
    {

        IUserRepository UserRepository { get; }
        ICategoryRepository CategoryRepository { get; }


        Task CommitAsync();

    }
}
