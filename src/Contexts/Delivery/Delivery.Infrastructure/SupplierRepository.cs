using System.Threading.Tasks;
using Delivery.Domain.SupplierAggregate;
using Microsoft.EntityFrameworkCore;
using Shared.Domain;
using Shared.Infrastructure;

namespace Delivery.Infrastructure
{
    public class SupplierRepository : Repository<Supplier, DeliveryDbContext>, ISupplierRepository
    {
        public SupplierRepository(DeliveryDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
            
        }

        public Task<Supplier> GetFirstFreeSupplier() // todo https://docs.microsoft.com/pl-pl/ef/core/saving/concurrency
        {
            return DbContext.Suppliers.FirstOrDefaultAsync(s => s.Status == SupplierStatus.Free);
        }
    }
}
