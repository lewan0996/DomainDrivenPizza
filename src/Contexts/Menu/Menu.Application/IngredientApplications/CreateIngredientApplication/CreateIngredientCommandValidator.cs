using FluentValidation;

namespace Menu.Application.IngredientApplications.CreateIngredientApplication
{
    public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
    {
        public CreateIngredientCommandValidator()
        {
            RuleFor(cmd => cmd.Name).NotEmpty();
            RuleFor(cmd => cmd.Description).NotEmpty();
            RuleFor(cmd => cmd.AvailableQuantity).GreaterThanOrEqualTo(0);
            RuleFor(cmd => cmd.UnitPrice).GreaterThanOrEqualTo(0);
        }
    }
}
