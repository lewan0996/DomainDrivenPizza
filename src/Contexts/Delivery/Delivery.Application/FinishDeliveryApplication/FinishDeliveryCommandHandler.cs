using System.Threading;
using System.Threading.Tasks;
using Delivery.Domain.OrderAggregate;
using Delivery.Domain.Services;
using MediatR;
using Shared.Domain;
using Shared.Domain.Exceptions;
using Shared.IntegrationEvents.Delivery;

namespace Delivery.Application.FinishDeliveryApplication
{
    // ReSharper disable once UnusedType.Global
    public class FinishDeliveryCommandHandler : AsyncRequestHandler<FinishDeliveryCommand>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMediator _mediator;
        private readonly OrderDeliveryService _orderDeliveryService;

        public FinishDeliveryCommandHandler(IRepository<Order> orderRepository, IMediator mediator, OrderDeliveryService orderDeliveryService)
        {
            _orderRepository = orderRepository;
            _mediator = mediator;
            _orderDeliveryService = orderDeliveryService;
        }

        protected override async Task Handle(FinishDeliveryCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);

            if (order == null)
            {
                throw new RecordNotFoundException(request.OrderId, nameof(Order));
            }

            await _orderDeliveryService.FinishDeliveryAsync(order);

            await _mediator.Publish(new OrderDeliveryFinishedIntegrationEvent(order.OrderingContextOrderId),
                cancellationToken);

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
