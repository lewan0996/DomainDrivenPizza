using System.Threading;
using System.Threading.Tasks;
using Application.Menu.Commands;
using Application.Menu.Exceptions;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.CommandHandlers
{
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
                throw new RecordNotFoundException(request.Id);
            }

            if (request.Name != null)
            {
                ingredientToUpdate.SetName(new ProductName(request.Name));
            }

            if (request.Description != null)
            {
                ingredientToUpdate.SetDescription(new ProductDescription(request.Description));
            }

            if (request.AvailableQuantity.HasValue)
            {
                if (request.AvailableQuantity > ingredientToUpdate.AvailableQuantity)
                {
                    ingredientToUpdate.AddToWarehouse(request.AvailableQuantity.Value -
                                                      ingredientToUpdate.AvailableQuantity);
                }
                else
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
