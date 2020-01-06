using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Menu.Domain.ProductAggregate;
using Shared.Domain;
using Shared.Domain.Exceptions;

namespace Menu.Application.IngredientApplications.DeleteIngredientApplication
{
    // ReSharper disable once UnusedType.Global
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
                throw new RecordNotFoundException(request.Id, nameof(Ingredient));
            }

            _ingredientRepository.Delete(ingredientToDelete);
        }
    }
}
