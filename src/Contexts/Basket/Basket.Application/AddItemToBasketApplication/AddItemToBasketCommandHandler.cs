using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Basket.Application.Queries.DTO;
using Basket.Domain.BasketAggregate;
using MediatR;
using Shared.Domain;

namespace Basket.Application.AddItemToBasketApplication
{
    // ReSharper disable once UnusedType.Global
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommand, BasketDTO>
    {
        private readonly IRepository<CustomerBasket> _basketRepository;
        private readonly IMapper _mapper;

        public AddItemToBasketCommandHandler(IRepository<CustomerBasket> basketRepository,
            IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<BasketDTO> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
        {
            CustomerBasket customerBasket;
            if (request.BasketId == null)
            {
                customerBasket = new CustomerBasket();
                await _basketRepository.AddAsync(customerBasket);
            }
            else
            {
                customerBasket = await _basketRepository.GetByIdAsync(request.BasketId.Value);
            }

            customerBasket.AddItemToBasket(request.ProductId, request.Quantity, request.UnitPrice);

            await _basketRepository.UnitOfWork.SaveEntitiesAsync();

            return _mapper.Map<BasketDTO>(customerBasket);
        }
    }
}
