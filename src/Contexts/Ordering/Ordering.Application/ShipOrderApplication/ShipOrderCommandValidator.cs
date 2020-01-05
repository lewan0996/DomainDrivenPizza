using FluentValidation;

namespace Ordering.Application.ShipOrderApplication
{
    // ReSharper disable once UnusedType.Global
    public class ShipOrderCommandValidator : AbstractValidator<ShipOrderCommand>
    {
        public ShipOrderCommandValidator()
        {
            RuleFor(c => c.OrderId).GreaterThan(0);
        }
    }
}
