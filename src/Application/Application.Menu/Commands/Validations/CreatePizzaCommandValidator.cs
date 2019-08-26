using FluentValidation;

namespace Application.Menu.Commands.Validations
{
    public class CreatePizzaCommandValidator : AbstractValidator<CreatePizzaCommand>
    {
        public CreatePizzaCommandValidator()
        {
            RuleFor(cmd => cmd.Name).NotEmpty();
            RuleFor(cmd => cmd.Description).NotEmpty();
            RuleFor(cmd => cmd.AvailableQuantity).GreaterThanOrEqualTo(0);
            RuleFor(cmd => cmd.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(cmd => cmd.CrustType).IsInEnum();
            RuleFor(cmd => cmd.IngredientIds).NotNull().NotEmpty();
        }
    }
}
