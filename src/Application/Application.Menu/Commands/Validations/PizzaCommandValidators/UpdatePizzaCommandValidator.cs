using Application.Menu.Commands.PizzaCommands;
using FluentValidation;

namespace Application.Menu.Commands.Validations.PizzaCommandValidators
{
    public class UpdatePizzaCommandValidator : AbstractValidator<UpdatePizzaCommand>
    {
        public UpdatePizzaCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().When(c => c.Name != null);
            RuleFor(c => c.Description).NotEmpty().When(c => c.Description != null);
            RuleFor(c => c.AvailableQuantity).GreaterThanOrEqualTo(0).When(c => c.AvailableQuantity.HasValue);
            RuleFor(c => c.UnitPrice).GreaterThanOrEqualTo(0).When(c => c.UnitPrice.HasValue);
            RuleFor(c => c.CrustType).IsInEnum().When(c => c.CrustType.HasValue);
        }
    }
}
