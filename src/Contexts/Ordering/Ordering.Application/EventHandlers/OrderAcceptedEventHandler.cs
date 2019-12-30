using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Ordering.Domain.OrderAggregate;
using Shared.Domain;
using Shared.IntegrationEvents.Menu;

namespace Ordering.Application.EventHandlers
{
    // ReSharper disable once UnusedType.Global
    public class OrderAcceptedEventHandler : INotificationHandler<OrderAcceptedIntegrationEvent>
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderAcceptedEventHandler(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(OrderAcceptedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(notification.OrderId);

            foreach (var orderItem in order.Items)
            {
                var priceFromMenu = notification.OrderItemInfoDictionary[orderItem.ProductId].UnitPrice;
                orderItem.SetUnitPrice(priceFromMenu);
            }

            order.StartPreparation();

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
