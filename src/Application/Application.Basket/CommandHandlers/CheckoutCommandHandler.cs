using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Basket.Commands;
using Application.IntegrationEvents.Basket;
using Application.Shared.Exceptions;
using Domain.Basket.Exceptions;
using Domain.SharedKernel;
using MediatR;

namespace Application.Basket.CommandHandlers
{
    public class CheckoutCommandHandler : AsyncRequestHandler<CheckoutCommand>
    {
        private readonly IRepository<Domain.Basket.BasketAggregate.Basket> _basketRepository;
        private readonly IMediator _mediator;

        public CheckoutCommandHandler(IRepository<Domain.Basket.BasketAggregate.Basket> basketRepository,
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
                basket.Items.Select(bi => (bi.ProductId, bi.Quantity)).ToList(),
                request.FirstName,
                request.LastName,
                request.EmailAddress, request.PhoneNumber, request.City, request.AddressLine1, request.AddressLine2,
                request.ZipCode
            );

            await _mediator.Publish(checkoutEvent, cancellationToken);
        }
    }
}
