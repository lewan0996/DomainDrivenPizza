using System.Threading;
using System.Threading.Tasks;
using Application.Menu.Commands;
using Application.Menu.Exceptions;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.CommandHandlers
{
    public class DeletePizzaCommandHandler :AsyncRequestHandler<DeletePizzaCommand>
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
                throw new RecordNotFoundException(request.Id);
            }

            _pizzaRepository.Delete(pizzaToDelete);
        }
    }
}
