using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shared.Application.Exceptions;
using Shared.Domain;

namespace Menu.Application.IngredientApplications.DeleteIngredientApplication
{
    public class DeleteIngredientCommandHandler : AsyncRequestHandler<DeleteIngredientCommand>
    {
        private readonly IRepository<Domain.ProductAggregate.Ingredient> _ingredientRepository;

        public DeleteIngredientCommandHandler(IRepository<Domain.ProductAggregate.Ingredient> ingredientRepository)
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
