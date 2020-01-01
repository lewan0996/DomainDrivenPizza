using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Menu.Domain.ProductAggregate;
using Shared.Application.Exceptions;
using Shared.Domain;

namespace Menu.Application.PizzaApplications.UpdatePizzaApplication
{
    // ReSharper disable once UnusedType.Global
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
                throw new RecordNotFoundException(request.Id, nameof(Pizza));
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

            if (request.IngredientIds != null)
            {
                var ingredients = new List<Ingredient>();
                foreach (var ingredientId in request.IngredientIds)
                {
                    ingredients.Add(await GetIngredientTask(ingredientId));
                }
                pizzaToUpdate.ReplaceIngredients(ingredients);
            }
        }

        private async Task<Ingredient> GetIngredientTask(int ingredientId)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(ingredientId);
            if (ingredient == null)
            {
                throw new RecordNotFoundException(ingredientId, nameof(Ingredient));
            }

            return ingredient;
        }
    }
}
