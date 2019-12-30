using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Basket.Domain.BasketAggregate;
using Basket.Domain.Exceptions;
using MediatR;
using Shared.Application.Exceptions;
using Shared.Domain;
using Shared.IntegrationEvents.Basket;

namespace Basket.Application.CheckoutApplication
{
    public class CheckoutCommandHandler : AsyncRequestHandler<CheckoutCommand>
    {
        private readonly IRepository<CustomerBasket> _basketRepository;
        private readonly IMediator _mediator;

        public CheckoutCommandHandler(IRepository<CustomerBasket> basketRepository,
            IMediator mediator)
        {
            _basketRepository = basketRepository;
            _mediator = mediator;
        }

        protected override async Task Handle(CheckoutCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetByIdAsync(request.BasketId);

            if (basket == null)
            {
                throw new RecordNotFoundException(request.BasketId);
            }

            if (basket.Items.Count == 0)
            {
                throw new BasketEmptyException(basket.Id);
            }

            var checkoutEvent = new BasketCheckedOutIntegrationEvent(
                request.BasketId,
                basket.Items.ToDictionary(bi => bi.ProductId
                    , bi => new BasketItemInfo
                    {
                        Id = bi.ProductId,
                        Quantity = bi.Quantity
                    }),
                request.FirstName,
                request.LastName,
                request.EmailAddress, request.PhoneNumber, request.City, request.AddressLine1, request.AddressLine2,
                request.ZipCode
            );

            basket.Clear();

            await _mediator.Publish(checkoutEvent, cancellationToken);

            await _basketRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
