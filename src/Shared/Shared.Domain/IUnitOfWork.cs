using System.Threading.Tasks;

namespace Shared.Domain
{
    public interface IUnitOfWork
    {
        Task<ITransaction> BeginTransactionAsync();
        Task CommitTransactionAsync(ITransaction transaction);
        bool HasActiveTransaction { get; }
        Task<int> SaveEntitiesAsync();
    }
}
