using Application.Basket.Commands;
using FluentValidation;

namespace Application.Basket.Validations
{
    public class RemoveItemFromBasketCommandValidator : AbstractValidator<RemoveItemFromBasketCommand>
    {
        public RemoveItemFromBasketCommandValidator()
        {
            RuleFor(cmd => cmd.BasketId).GreaterThan(0);
            RuleFor(cmd => cmd.ProductId).GreaterThan(0);
        }
    }
}
