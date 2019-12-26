using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shared.Application.Exceptions;
using Shared.Domain;

namespace Basket.Application.RemoveItemFromBasketApplication
{
    public class RemoveItemFromBasketCommandHandler : AsyncRequestHandler<RemoveItemFromBasketCommand>
    {
        private readonly IRepository<Domain.BasketAggregate.CustomerBasket> _basketRepository;

        public RemoveItemFromBasketCommandHandler(IRepository<Domain.BasketAggregate.CustomerBasket> basketRepository)
        {
            _basketRepository = basketRepository;
        }

        protected override async Task Handle(RemoveItemFromBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetByIdAsync(request.BasketId);

            if (basket == null)
            {
                throw new RecordNotFoundException(request.BasketId);
            }

            basket.RemoveItemFromBasket(request.ProductId);
        }
    }
}
