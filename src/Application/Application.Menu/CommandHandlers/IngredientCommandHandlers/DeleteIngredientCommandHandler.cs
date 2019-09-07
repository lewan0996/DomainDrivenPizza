using System.Threading;
using System.Threading.Tasks;
using Application.Menu.Commands.IngredientCommands;
using Application.Menu.Exceptions;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.CommandHandlers.IngredientCommandHandlers
{
    public class DeleteIngredientCommandHandler : AsyncRequestHandler<DeleteIngredientCommand>
    {
        private readonly IRepository<Domain.Menu.ProductAggregate.Ingredient> _ingredientRepository;

        public DeleteIngredientCommandHandler(IRepository<Domain.Menu.ProductAggregate.Ingredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        protected override async Task Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredientToDelete = await _ingredientRepository.GetByIdAsync(request.Id);
            if (ingredientToDelete == null)
            {
                throw new RecordNotFoundException(request.Id);
            }

            _ingredientRepository.Delete(ingredientToDelete);
        }
    }
}
