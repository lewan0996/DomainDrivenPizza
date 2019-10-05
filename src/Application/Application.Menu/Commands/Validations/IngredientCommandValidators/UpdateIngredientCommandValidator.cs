using Application.Menu.Commands.IngredientCommands;
using FluentValidation;

namespace Application.Menu.Commands.Validations.IngredientCommandValidators
{
    public class UpdateIngredientCommandValidator: AbstractValidator<UpdateIngredientCommand>
    {
        public UpdateIngredientCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().When(c => c.Name != null);
            RuleFor(c => c.Description).NotEmpty().When(c => c.Description != null);
            RuleFor(c => c.AvailableQuantity).GreaterThanOrEqualTo(0).When(c => c.AvailableQuantity.HasValue);
            RuleFor(c => c.UnitPrice).GreaterThanOrEqualTo(0).When(c => c.UnitPrice.HasValue);
        }
    }
}
