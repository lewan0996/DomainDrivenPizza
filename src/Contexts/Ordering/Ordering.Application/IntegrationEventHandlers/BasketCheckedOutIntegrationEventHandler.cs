using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ordering.Application.CreateOrderApplication;
using Shared.IntegrationEvents.Basket;

namespace Ordering.Application.IntegrationEventHandlers
{
    public class BasketCheckedOutIntegrationEventHandler : INotificationHandler<BasketCheckedOutIntegrationEvent>
    {
        private readonly IMediator _mediator;

        public BasketCheckedOutIntegrationEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(BasketCheckedOutIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var createOrderCommand = new CreateOrderCommand(
                notification.FirstName,
                notification.LastName,
                notification.EmailAddress,
                notification.PhoneNumber,
                notification.City,
                notification.AddressLine1,
                notification.AddressLine2,
                notification.ZipCode,
                notification.BasketItems);

            await _mediator.Send(createOrderCommand, cancellationToken);
        }
    }
}
