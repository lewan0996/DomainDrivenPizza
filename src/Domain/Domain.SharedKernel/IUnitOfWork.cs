using System.Threading.Tasks;

namespace Domain.SharedKernel
{
    public interface IUnitOfWork
    {
        Task<ITransaction> BeginTransactionAsync();
        Task CommitTransactionAsync(ITransaction transaction);
        bool HasActiveTransaction { get; }
        Task<int> SaveEntitiesAsync();
    }
}
