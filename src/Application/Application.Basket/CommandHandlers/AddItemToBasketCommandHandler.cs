using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Basket.Commands;
using Application.Basket.Queries.DTO;
using AutoMapper;
using Domain.SharedKernel;
using MediatR;

namespace Application.Basket.CommandHandlers
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommand, BasketDTO>
    {
        private readonly IRepository<Domain.Basket.BasketAggregate.Basket> _basketRepository;
        private readonly IMapper _mapper;

        public AddItemToBasketCommandHandler(IRepository<Domain.Basket.BasketAggregate.Basket> basketRepository,
            IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<BasketDTO> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
        {
            Domain.Basket.BasketAggregate.Basket basket;
            if (request.BasketId == null)
            {
                basket = new Domain.Basket.BasketAggregate.Basket();
                await _basketRepository.AddAsync(basket);
            }
            else
            {
                basket = await _basketRepository.GetByIdAsync(request.BasketId.Value);
            }

            basket.AddItemToBasket(request.ProductId, request.Quantity);

            return _mapper.Map<BasketDTO>(basket);
        }
    }
}
