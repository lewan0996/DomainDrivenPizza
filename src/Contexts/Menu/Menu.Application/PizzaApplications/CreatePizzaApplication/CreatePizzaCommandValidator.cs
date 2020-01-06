using FluentValidation;

namespace Menu.Application.PizzaApplications.CreatePizzaApplication
{
    public class CreatePizzaCommandValidator : AbstractValidator<CreatePizzaCommand>
    {
        public CreatePizzaCommandValidator()
        {
            RuleFor(cmd => cmd.Name).NotEmpty();
            RuleFor(cmd => cmd.Description).NotEmpty();
            RuleFor(cmd => cmd.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(cmd => cmd.IngredientIds).NotNull().NotEmpty();
        }
    }
}
