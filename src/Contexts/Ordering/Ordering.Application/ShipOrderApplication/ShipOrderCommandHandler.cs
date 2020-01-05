using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ordering.Domain.OrderAggregate;
using Shared.Domain;
using Shared.Domain.Exceptions;
using Shared.IntegrationEvents.Menu;
using Shared.IntegrationEvents.Ordering;

namespace Ordering.Application.ShipOrderApplication
{
    // ReSharper disable once UnusedType.Global
    public class ShipOrderCommandHandler : AsyncRequestHandler<ShipOrderCommand>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMediator _mediator;

        public ShipOrderCommandHandler(IRepository<Order> orderRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        protected override async Task Handle(ShipOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);

            if (order == null)
            {
                throw new RecordNotFoundException(request.OrderId, nameof(Order));
            }

            order.Ship();

            var orderShippedIntegrationEvent = new OrderShippedIntegrationEvent(
                order.Address.City, 
                order.Address.AddressLine1, 
                order.Address.AddressLine2, 
                order.Address.ZipCode,
                order.Client.FirstName, 
                order.Client.LastName, 
                order.Client.EmailAddress, 
                order.Client.PhoneNumber,
                order.Items.Select(oi => 
                        // ReSharper disable once PossibleInvalidOperationException Aggregate invariant ensures that all prices are set.
                        new ValidatedOrderItemInfo(oi.ProductId, oi.Quantity, oi.UnitPrice.Value))
                    .ToList()
            );

            await _mediator.Publish(orderShippedIntegrationEvent, cancellationToken);

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
