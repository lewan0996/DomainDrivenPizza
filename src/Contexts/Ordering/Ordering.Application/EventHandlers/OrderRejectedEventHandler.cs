using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ordering.Domain.OrderAggregate;
using Shared.Domain;
using Shared.IntegrationEvents.Menu;

namespace Ordering.Application.EventHandlers
{
    // ReSharper disable once UnusedType.Global
    public class OrderRejectedEventHandler : INotificationHandler<OrderRejectedIntegrationEvent>
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderRejectedEventHandler(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(OrderRejectedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(notification.OrderId);
            
            order.Cancel();

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
