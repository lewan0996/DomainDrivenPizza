using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ordering.Application.Queries.DTO;
using Ordering.Domain.OrderAggregate;
using Shared.Domain;
using Shared.IntegrationEvents.Ordering;

namespace Ordering.Application.CreateOrderApplication
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDTO>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateOrderCommandHandler(IRepository<Order> orderRepository, IMapper mapper, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<OrderDTO> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(
                request.ClientFirstName,
                request.ClientLastName,
                request.ClientEmailAddress,
                request.ClientPhoneNumber
                );

            var address = new Address(
                request.City,
                request.AddressLine1,
                request.AddressLine2,
                request.ZipCode);

            var orderItems = request.BasketItems
                .Select(kv => new OrderItem(kv.Key, kv.Value.Quantity, kv.Value.UnitPrice))
                .ToList();

            var order = new Order(client, address, orderItems);

            await _orderRepository.AddAsync(order);

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();

            var orderCreatedEvent = new NewOrderCreatedIntegrationEvent(
                order.Id,
                request.BasketItems
            );

            await _mediator.Publish(orderCreatedEvent, cancellationToken);

            return _mapper.Map<OrderDTO>(order);
        }
    }
}
