using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Menu.Domain.ProductAggregate;
using Shared.Domain;
using Shared.Domain.Exceptions;

namespace Menu.Application.IngredientApplications.UpdateIngredientApplication
{
    // ReSharper disable once UnusedType.Global
    public class UpdateIngredientCommandHandler : AsyncRequestHandler<UpdateIngredientCommand>
    {
        private readonly IRepository<Ingredient> _ingredientRepository;
        public UpdateIngredientCommandHandler(IRepository<Ingredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        protected override async Task Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredientToUpdate = await _ingredientRepository.GetByIdAsync(request.Id);

            if (ingredientToUpdate == null)
            {
                throw new RecordNotFoundException(request.Id, nameof(Ingredient));
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
