using System.Threading;
using System.Threading.Tasks;
using Application.Basket.Commands;
using Application.Shared.Exceptions;
using Domain.SharedKernel;
using MediatR;

namespace Application.Basket.CommandHandlers
{
    public class AddItemToBasketCommandHandler : AsyncRequestHandler<AddItemToBasketCommand>
    {
        private readonly IRepository<Domain.Basket.BasketAggregate.Basket> _basketRepository;

        public AddItemToBasketCommandHandler(IRepository<Domain.Basket.BasketAggregate.Basket> basketRepository)
        {
            _basketRepository = basketRepository;
        }

        protected override async Task Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetByIdAsync(request.BasketId);

            if (basket == null)
            {
                throw new RecordNotFoundException(request.BasketId);
            }

            basket.AddItemToBasket(request.ProductId, request.Quantity);
        }
    }
}
