using FluentValidation;

namespace Basket.Application.AddItemToBasketApplication
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
