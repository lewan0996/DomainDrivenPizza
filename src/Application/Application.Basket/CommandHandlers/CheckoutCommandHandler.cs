using System.Threading;
using System.Threading.Tasks;
using Application.Basket.Commands;
using Application.Shared.Exceptions;
using Domain.Basket.Exceptions;
using Domain.SharedKernel;
using MediatR;

namespace Application.Basket.CommandHandlers
{
    public class CheckoutCommandHandler : AsyncRequestHandler<CheckoutCommand>
    {
        private readonly IRepository<Domain.Basket.BasketAggregate.Basket> _basketRepository;

        public CheckoutCommandHandler(IRepository<Domain.Basket.BasketAggregate.Basket> basketRepository)
        {
            _basketRepository = basketRepository;
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

            // raise the integration event
        }
    }
}
