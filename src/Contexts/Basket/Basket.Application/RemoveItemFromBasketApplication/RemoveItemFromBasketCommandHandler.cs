using System.Threading;
using System.Threading.Tasks;
using Basket.Domain.BasketAggregate;
using MediatR;
using Shared.Domain;
using Shared.Domain.Exceptions;

namespace Basket.Application.RemoveItemFromBasketApplication
{
    public class RemoveItemFromBasketCommandHandler : AsyncRequestHandler<RemoveItemFromBasketCommand>
    {
        private readonly IRepository<CustomerBasket> _basketRepository;

        public RemoveItemFromBasketCommandHandler(IRepository<CustomerBasket> basketRepository)
        {
            _basketRepository = basketRepository;
        }

        protected override async Task Handle(RemoveItemFromBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetByIdAsync(request.BasketId);

            if (basket == null)
            {
                throw new RecordNotFoundException(request.BasketId, nameof(CustomerBasket));
            }

            basket.RemoveItemFromBasket(request.ProductId);
        }
    }
}
