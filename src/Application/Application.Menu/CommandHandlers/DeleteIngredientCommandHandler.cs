using System.Threading;
using System.Threading.Tasks;
using Application.Menu.Commands;
using Application.Menu.Exceptions;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.CommandHandlers
{
    public class DeleteIngredientCommandHandler : AsyncRequestHandler<DeleteIngredientCommand>
    {
        private readonly IRepository<Ingredient> _ingredientRepository;

        public DeleteIngredientCommandHandler(IRepository<Ingredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        protected override async Task Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredientToDelete = await _ingredientRepository.GetByIdAsync(request.Id);
            if (ingredientToDelete == null)
            {
                throw new RecordNotFoundException();
            }

            _ingredientRepository.Delete(ingredientToDelete);
        }
    }
}
