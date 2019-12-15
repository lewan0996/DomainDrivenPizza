using System.Threading;
using System.Threading.Tasks;
using Application.IntegrationEvents.Basket;
using Application.Ordering.Commands;
using MediatR;

namespace Application.Ordering.EventHandlers
{
    public class BasketCheckedOutEventHandler : INotificationHandler<BasketCheckedOutIntegrationEvent>
    {
        private readonly IMediator _mediator;

        public BasketCheckedOutEventHandler(IMediator mediator)
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
                notification.BasketItemIdsAndQuantity);

            await _mediator.Send(createOrderCommand, cancellationToken);
        }
    }
}
