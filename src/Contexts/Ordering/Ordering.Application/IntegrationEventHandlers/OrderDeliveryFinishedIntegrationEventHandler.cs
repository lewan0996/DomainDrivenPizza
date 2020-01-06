using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ordering.Domain.OrderAggregate;
using Shared.Domain;
using Shared.Domain.Exceptions;
using Shared.IntegrationEvents.Delivery;

namespace Ordering.Application.IntegrationEventHandlers
{
    // ReSharper disable once UnusedType.Global
    public class OrderDeliveryFinishedIntegrationEventHandler : INotificationHandler<OrderDeliveryFinishedIntegrationEvent>
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderDeliveryFinishedIntegrationEventHandler(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(OrderDeliveryFinishedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(notification.OrderId);

            if (order == null)
            {
                throw new RecordNotFoundException(notification.OrderId, nameof(Order));
            }

            order.Complete();

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
