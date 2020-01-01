using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Menu.Domain.ProductAggregate;
using Shared.Application.Exceptions;
using Shared.Domain;
using Shared.IntegrationEvents.Menu;
using Shared.IntegrationEvents.Ordering;

namespace Menu.Application.EventHandlers
{
    // ReSharper disable once UnusedType.Global
    public class NewOrderCreatedEventHandler : INotificationHandler<NewOrderCreatedIntegrationEvent>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Pizza> _pizzaRepository; //todo replace with product repository after TPT is introduced

        public NewOrderCreatedEventHandler(IMediator mediator, IRepository<Pizza> pizzaRepository)
        {
            _mediator = mediator;
            _pizzaRepository = pizzaRepository;
        }

        public async Task Handle(NewOrderCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var validatedOrderItemInfos = new Dictionary<int, ValidatedOrderItemInfo>();
            foreach (var (productId, basketItemInfo) in notification.BasketItems)
            {
                var product = await _pizzaRepository.GetByIdAsync(productId); // todo get all products with single query

                if (product == null)
                {
                    throw new RecordNotFoundException(productId, nameof(Product));
                }

                var requestedQuantity = basketItemInfo.Quantity;

                if (requestedQuantity > product.AvailableQuantity)
                {
                    await _mediator.Publish(new OrderRejectedIntegrationEvent(notification.OrderId),
                        cancellationToken); // todo Implement rejection reason
                    return;
                }
            }

            foreach (var (productId, basketItemInfo) in notification.BasketItems)
            {
                var product = await _pizzaRepository.GetByIdAsync(productId); // todo get all products with single query

                var requestedQuantity = basketItemInfo.Quantity;

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
