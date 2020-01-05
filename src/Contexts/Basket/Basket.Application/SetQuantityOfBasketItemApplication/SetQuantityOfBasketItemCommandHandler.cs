using System.Threading;
using System.Threading.Tasks;
using Basket.Domain.BasketAggregate;
using MediatR;
using Shared.Domain;
using Shared.Domain.Exceptions;

namespace Basket.Application.SetQuantityOfBasketItemApplication
{
    // ReSharper disable once UnusedType.Global
    public class SetQuantityOfBasketItemCommandHandler : AsyncRequestHandler<SetQuantityOfBasketItemCommand>
    {
        private readonly IRepository<CustomerBasket> _basketRepository;

        public SetQuantityOfBasketItemCommandHandler(IRepository<CustomerBasket> basketRepository)
        {
            _basketRepository = basketRepository;
        }

        protected override async Task Handle(SetQuantityOfBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetByIdAsync(request.BasketId);

            if (basket == null)
            {
                throw new RecordNotFoundException(request.BasketId, nameof(CustomerBasket));
            }

            basket.SetItemQuantity(request.ProductId, request.Quantity);
        }
    }
}
