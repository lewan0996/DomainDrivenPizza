using Application.Basket.Commands;
using FluentValidation;

namespace Application.Basket.Validations
{
    public class AddItemToBasketCommandValidator : AbstractValidator<AddItemToBasketCommand>
    {
        public AddItemToBasketCommandValidator()
        {
            RuleFor(cmd => cmd.Quantity).GreaterThan(0);
            RuleFor(cmd => cmd.BasketId).GreaterThan(0);
            RuleFor(cmd => cmd.ProductId).GreaterThan(0);
        }
    }
}
