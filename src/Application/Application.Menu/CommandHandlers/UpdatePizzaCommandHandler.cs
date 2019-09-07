using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Menu.Commands;
using Application.Menu.Exceptions;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Menu.CommandHandlers
{
    public class UpdatePizzaCommandHandler : AsyncRequestHandler<UpdatePizzaCommand>
    {
        private readonly IRepository<Pizza> _pizzaRepository;
        private readonly IRepository<Ingredient> _ingredientRepository;

        public UpdatePizzaCommandHandler(IRepository<Pizza> pizzaRepository,
            IRepository<Ingredient> ingredientRepository)
        {
            _pizzaRepository = pizzaRepository;
            _ingredientRepository = ingredientRepository;
        }

        protected override async Task Handle(UpdatePizzaCommand request, CancellationToken cancellationToken)
        {
            var pizzaToUpdate = await _pizzaRepository.GetByIdAsync(request.Id);

            if (pizzaToUpdate == null)
            {
                throw new RecordNotFoundException(request.Id);
            }

            if (request.Name != null)
            {
                pizzaToUpdate.SetName(request.Name);
            }

            if (request.Description != null)
            {
                pizzaToUpdate.SetDescription(request.Description);
            }

            if (request.UnitPrice.HasValue)
            {
                pizzaToUpdate.SetUnitPrice(request.UnitPrice.Value);
            }

            if (request.AvailableQuantity.HasValue)
            {
                if (request.AvailableQuantity > pizzaToUpdate.AvailableQuantity)
                {
                    pizzaToUpdate.AddToWarehouse(request.AvailableQuantity.Value -
                                                      pizzaToUpdate.AvailableQuantity);
                }
                else
                {
                    pizzaToUpdate.TakeFromWarehouse(pizzaToUpdate.AvailableQuantity -
                                                         request.AvailableQuantity.Value);
                }
            }

            if (request.CrustType.HasValue)
            {
                pizzaToUpdate.SetCrustType(request.CrustType.Value);
            }

            if (request.IngredientIds != null)
            {
                var getIngredientTasks = request.IngredientIds.Select(GetIngredientTask).ToArray();
                var ingredients = await Task.WhenAll(getIngredientTasks);
                pizzaToUpdate.ReplaceIngredients(ingredients);
            }
        }

        private async Task<Ingredient> GetIngredientTask(int ingredientId)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(ingredientId);
            if (ingredient == null)
            {
                throw new RecordNotFoundException(ingredientId);
            }

            return ingredient;
        }
    }
}
