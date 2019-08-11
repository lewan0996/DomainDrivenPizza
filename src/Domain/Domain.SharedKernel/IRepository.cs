using System.Threading.Tasks;

namespace Domain.SharedKernel
{
    public interface IRepository<T> where T: AggregateRoot
    {
        Task Add(T item);
        Task<T> GetById(int id);
    }
}
