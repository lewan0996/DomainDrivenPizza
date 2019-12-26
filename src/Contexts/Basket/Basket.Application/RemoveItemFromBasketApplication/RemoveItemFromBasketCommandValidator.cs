using FluentValidation;

namespace Basket.Application.RemoveItemFromBasketApplication
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
