using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shared.Application.Exceptions;
using Shared.Domain;

namespace Menu.Application.PizzaApplications.DeletePizzaApplication
{
    public class DeletePizzaCommandHandler :AsyncRequestHandler<DeletePizzaCommand>
    {
        private readonly IRepository<Domain.ProductAggregate.Pizza> _pizzaRepository;

        public DeletePizzaCommandHandler(IRepository<Domain.ProductAggregate.Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        protected override async Task Handle(DeletePizzaCommand request, CancellationToken cancellationToken)
        {
            var pizzaToDelete = await _pizzaRepository.GetByIdAsync(request.Id);
            if (pizzaToDelete == null)
            {
                throw new RecordNotFoundException(request.Id);
            }

            _pizzaRepository.Delete(pizzaToDelete);
        }
    }
}
