using System.Threading.Tasks;
using Delivery.Domain.OrderAggregate;
using Delivery.Domain.SupplierAggregate;
using Shared.Domain;
using Shared.Domain.Exceptions;

namespace Delivery.Domain.Services
{
    public class OrderDeliveryService
    {
        private readonly IRepository<Supplier> _supplierRepository;

        public OrderDeliveryService(IRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task StartDeliveryAsync(Order order)
        {
            var supplier = await _supplierRepository.GetByIdAsync(order.SupplierId);

            if (supplier == null)
            {
                throw new RecordNotFoundException(order.SupplierId, nameof(Supplier));
            }

            order.StartDelivery();
            supplier.StartDelivery();
        }

        public async Task FinishDeliveryAsync(Order order)
        {
            var supplier = await _supplierRepository.GetByIdAsync(order.SupplierId);

            if (supplier == null)
            {
                throw new RecordNotFoundException(order.SupplierId, nameof(Supplier));
            }

            order.FinishDelivery();
            supplier.FinishDelivery();
        }
    }
}
