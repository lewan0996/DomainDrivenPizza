using System.Threading;
using System.Threading.Tasks;
using Application.Menu.Commands.PizzaCommands;
using Application.Shared.Exceptions;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.CommandHandlers.PizzaCommandHandlers
{
    public class DeletePizzaCommandHandler :AsyncRequestHandler<DeletePizzaCommand>
    {
        private readonly IRepository<Domain.Menu.ProductAggregate.Pizza> _pizzaRepository;

        public DeletePizzaCommandHandler(IRepository<Domain.Menu.ProductAggregate.Pizza> pizzaRepository)
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
