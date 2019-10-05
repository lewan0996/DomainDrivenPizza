using System.Threading;
using System.Threading.Tasks;
using Application.Menu.Commands.IngredientCommands;
using Application.Shared.Exceptions;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.CommandHandlers.IngredientCommandHandlers
{
    public class UpdateIngredientCommandHandler : AsyncRequestHandler<UpdateIngredientCommand>
    {
        private readonly IRepository<Domain.Menu.ProductAggregate.Ingredient> _ingredientRepository;
        public UpdateIngredientCommandHandler(IRepository<Domain.Menu.ProductAggregate.Ingredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        protected override async Task Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredientToUpdate = await _ingredientRepository.GetByIdAsync(request.Id);

            if (ingredientToUpdate == null)
            {
                throw new RecordNotFoundException(request.Id);
            }

            if (request.Name != null)
            {
                ingredientToUpdate.SetName(request.Name);
            }

            if (request.Description != null)
            {
                ingredientToUpdate.SetDescription(request.Description);
            }

            if (request.AvailableQuantity.HasValue)
            {
                if (request.AvailableQuantity > ingredientToUpdate.AvailableQuantity)
                {
                    ingredientToUpdate.AddToWarehouse(request.AvailableQuantity.Value -
                                                      ingredientToUpdate.AvailableQuantity);
                }
                if (request.AvailableQuantity < ingredientToUpdate.AvailableQuantity)
                {
                    ingredientToUpdate.TakeFromWarehouse(ingredientToUpdate.AvailableQuantity -
                                                      request.AvailableQuantity.Value);
                }
            }

            if (request.UnitPrice.HasValue)
            {
                ingredientToUpdate.SetUnitPrice(request.UnitPrice.Value);
            }

            if (request.IsSpicy.HasValue)
            {
                ingredientToUpdate.SetSpiciness(request.IsSpicy.Value);
            }

            if (request.IsVegetarian.HasValue)
            {
                ingredientToUpdate.SetVegetarianism(request.IsVegetarian.Value);
            }

            if (request.IsVegan.HasValue)
            {
                ingredientToUpdate.SetVegan(request.IsVegan.Value);
            }
        }
    }
}
