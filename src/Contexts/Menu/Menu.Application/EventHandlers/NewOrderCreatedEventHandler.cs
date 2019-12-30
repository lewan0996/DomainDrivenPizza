using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Menu.Domain.ProductAggregate;
using Shared.Domain;
using Shared.IntegrationEvents.Menu;
using Shared.IntegrationEvents.Ordering;

namespace Menu.Application.EventHandlers
{
    // ReSharper disable once UnusedType.Global
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
            var validatedOrderItemInfos = new Dictionary<int, ValidatedOrderItemInfo>();
            foreach (var (productId, basketItemInfo) in notification.BasketItems)
            {
                var product = await _productRepository.GetByIdAsync(productId); // todo get all products with single query
                
                var requestedQuantity = basketItemInfo.Quantity;

                if (product is Ingredient || requestedQuantity > product.AvailableQuantity)
                {
                    await _mediator.Publish(new OrderRejectedIntegrationEvent(notification.OrderId), cancellationToken); // todo Implement rejection reason
                    return;
                }

                var validatedOrderItemInfo =
                    new ValidatedOrderItemInfo(product.Id, requestedQuantity, product.UnitPrice);
                validatedOrderItemInfos.Add(product.Id, validatedOrderItemInfo);

                product.TakeFromWarehouse(requestedQuantity);
            }

            await _mediator.Publish(new OrderAcceptedIntegrationEvent(notification.OrderId, validatedOrderItemInfos),
                cancellationToken);
        }
    }
}
