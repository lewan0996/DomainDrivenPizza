using System.Threading;
using System.Threading.Tasks;
using Delivery.Domain.DomainEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Delivery.Application.DomainEventHandlers
{
    // ReSharper disable once UnusedType.Global
    public class OrderShippedDomainEventHandler : INotificationHandler<OrderShippedDomainEvent>
    {
        private readonly ILogger<OrderShippedDomainEventHandler> _logger;

        public OrderShippedDomainEventHandler(ILogger<OrderShippedDomainEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(OrderShippedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.Log(LogLevel.Information, $"New order has been shipped!\n{notification.Order}");

            return Task.CompletedTask;
        }
    }
}
