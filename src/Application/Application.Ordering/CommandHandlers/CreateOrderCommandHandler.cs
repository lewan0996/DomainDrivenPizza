using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Ordering.Commands;
using Application.Ordering.Queries.DTO;
using AutoMapper;
using Domain.Ordering.OrderAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Ordering.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDTO>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
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

            var orderItems = request.Items
                .Select(dto => new OrderItem(dto.ProductId, dto.Quantity, dto.UnitPrice)
                ).ToList();

            var order = new Order(client, address, orderItems);

            await _orderRepository.AddAsync(order);

            // raise the integration event to validate the order

            return _mapper.Map<OrderDTO>(order);
        }
    }
}
