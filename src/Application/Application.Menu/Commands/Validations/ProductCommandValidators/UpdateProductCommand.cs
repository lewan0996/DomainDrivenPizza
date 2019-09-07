using Application.Menu.Commands.ProductCommands;
using Domain.Menu.ProductAggregate;
using FluentValidation;

namespace Application.Menu.Commands.Validations.ProductCommandValidators
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(c => c.Type)
                .NotEqual(ProductType.Pizza)
                .NotEqual(ProductType.Ingredient)
                .WithMessage("Pizzas and ingredients are managed by their own endpoints")
                .When(c => c.Type.HasValue);

            RuleFor(c => c.Name).NotEmpty().When(c => c.Name != null);
            RuleFor(c => c.Description).NotEmpty().When(c => c.Description != null);
            RuleFor(c => c.AvailableQuantity).GreaterThanOrEqualTo(0).When(c => c.AvailableQuantity.HasValue);
            RuleFor(c => c.UnitPrice).GreaterThanOrEqualTo(0).When(c => c.UnitPrice.HasValue);
        }
    }
}
