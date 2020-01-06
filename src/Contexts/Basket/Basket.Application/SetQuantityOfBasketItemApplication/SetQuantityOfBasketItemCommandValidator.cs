using FluentValidation;

namespace Basket.Application.SetQuantityOfBasketItemApplication
{
    public class SetQuantityOfBasketItemCommandValidator : AbstractValidator<SetQuantityOfBasketItemCommand>
    {
        public SetQuantityOfBasketItemCommandValidator()
        {
            RuleFor(cmd => cmd.Quantity).GreaterThan(0);
            RuleFor(cmd => cmd.BasketId).GreaterThan(0);
            RuleFor(cmd => cmd.ProductId).GreaterThan(0);
        }
    }
}
