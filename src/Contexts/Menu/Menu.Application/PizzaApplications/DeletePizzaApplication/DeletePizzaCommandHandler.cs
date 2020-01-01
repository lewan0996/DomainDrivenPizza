using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Menu.Domain.ProductAggregate;
using Shared.Application.Exceptions;
using Shared.Domain;

namespace Menu.Application.PizzaApplications.DeletePizzaApplication
{
    // ReSharper disable once UnusedType.Global
    public class DeletePizzaCommandHandler : AsyncRequestHandler<DeletePizzaCommand>
    {
        private readonly IRepository<Pizza> _pizzaRepository;

        public DeletePizzaCommandHandler(IRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        protected override async Task Handle(DeletePizzaCommand request, CancellationToken cancellationToken)
        {
            var pizzaToDelete = await _pizzaRepository.GetByIdAsync(request.Id);
            if (pizzaToDelete == null)
            {
                throw new RecordNotFoundException(request.Id, nameof(Pizza));
            }

            _pizzaRepository.Delete(pizzaToDelete);
        }
    }
}
