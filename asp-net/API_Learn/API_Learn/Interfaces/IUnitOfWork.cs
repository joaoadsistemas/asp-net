using DSLearn.Interfaces;

namespace ApiCatalogo.Repositories
{
    public interface IUnitOfWork
    {

        IUserRepository UserRepository { get; }
        
        Task CommitAsync();

    }
}
