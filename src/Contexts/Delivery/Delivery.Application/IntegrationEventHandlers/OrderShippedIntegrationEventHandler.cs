using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Delivery.Domain.OrderAggregate;
using Delivery.Domain.Services;
using Delivery.Domain.SupplierAggregate;
using MediatR;
using Shared.Domain;
using Shared.Domain.ValueObjects;
using Shared.IntegrationEvents.Ordering;

namespace Delivery.Application.IntegrationEventHandlers
{
    public class OrderShippedIntegrationEventHandler : INotificationHandler<OrderShippedIntegrationEvent>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly OrderDeliveryService _orderDeliveryService;

        public OrderShippedIntegrationEventHandler(IRepository<Order> orderRepository, ISupplierRepository supplierRepository, OrderDeliveryService orderDeliveryService)
        {
            _orderRepository = orderRepository;
            _supplierRepository = supplierRepository;
            _orderDeliveryService = orderDeliveryService;
        }

        public async Task Handle(OrderShippedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetFirstFreeSupplier(); // ensure that supplier is locked (increase transaction isolation level)

            var order = new Order(
                new Address(notification.City, notification.AddressLine1, notification.AddressLine2,
                    notification.ZipCode),
                new Client(notification.FirstName, notification.LastName, notification.EmailAddress,
                    notification.PhoneNumber),
                supplier.Id,
                notification.Items.Select(i =>
                    new OrderItem(i.ProductId, i.Quantity, i.UnitPrice)
                ).ToList(),
                notification.OrderId);

            await _orderDeliveryService.StartDeliveryAsync(order);

            await _orderRepository.AddAsync(order);

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
