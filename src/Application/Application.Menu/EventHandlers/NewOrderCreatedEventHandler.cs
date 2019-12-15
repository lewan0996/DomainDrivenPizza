using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.IntegrationEvents.Ordering;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.EventHandlers
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
            var productIds = notification.ItemsIdsAndQuantity.Select(i => i.id).ToList();

            foreach (var productId in productIds)
            {
                var product = await _productRepository.GetByIdAsync(productId);
                var requestedQuantity = notification.ItemsIdsAndQuantity.First(i => i.id == productId).quantity;

                if (requestedQuantity > product.AvailableQuantity)
                {
                    // raise event to cancel order
                    break;
                }

                product.TakeFromWarehouse(requestedQuantity);

            }
        }
    }
}
