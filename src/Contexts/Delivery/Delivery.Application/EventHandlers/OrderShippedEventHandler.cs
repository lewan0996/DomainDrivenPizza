﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Delivery.Domain.OrderAggregate;
using Delivery.Domain.SupplierAggregate;
using MediatR;
using Shared.Domain;
using Shared.Domain.ValueObjects;
using Shared.IntegrationEvents.Ordering;

namespace Delivery.Application.EventHandlers
{
    public class OrderShippedEventHandler : INotificationHandler<OrderShippedIntegrationEvent>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly ISupplierRepository _supplierRepository;

        public OrderShippedEventHandler(IRepository<Order> orderRepository, ISupplierRepository supplierRepository)
        {
            _orderRepository = orderRepository;
            _supplierRepository = supplierRepository;
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
                    new OrderItem(i.ProductId, i.Quantity, i.UnitPrice)).ToList());

            order.StartDelivery();

            await _orderRepository.AddAsync(order);

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
