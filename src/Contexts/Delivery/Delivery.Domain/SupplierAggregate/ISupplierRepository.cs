using System.Threading.Tasks;

namespace Delivery.Domain.SupplierAggregate
{
    public interface ISupplierRepository
    {
        Task<Supplier> GetFirstFreeSupplier();
    }
}
