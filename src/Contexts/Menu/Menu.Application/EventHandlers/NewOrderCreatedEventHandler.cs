using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Menu.Domain.ProductAggregate;
using Shared.Domain;
using Shared.IntegrationEvents.Ordering;

namespace Menu.Application.EventHandlers
{
    public class NewOrderCreatedEventHandler : INotificationHandler<NewOrderCreatedIntegrationEvent>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Product> _productRepository;

        public NewOrderCreatedEventHandler(IMediator mediator, IRepository<Product> productRepository)
        {
            _mediator = mediator;
            _productRepository = productRepository;
        }

        public async Task Handle(NewOrderCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            foreach (var basketItem in notification.BasketItems)
            {
                var product = await _productRepository.GetByIdAsync(basketItem.Key);
                var requestedQuantity = basketItem.Value.Quantity;

                if (requestedQuantity > product.AvailableQuantity)
                {
                    // raise event to cancel order
                    break;
                }

                basketItem.Value.UnitPrice = product.UnitPrice;

                product.TakeFromWarehouse(requestedQuantity);
            }

            // raise event to confirm order with newest prices (return notification.BasketItems)
        }
    }
}
