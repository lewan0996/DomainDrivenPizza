using FluentValidation;

namespace Delivery.Application.FinishDeliveryApplication
{
    // ReSharper disable once UnusedType.Global
    public class FinishDeliveryCommandValidator : AbstractValidator<FinishDeliveryCommand>
    {
        public FinishDeliveryCommandValidator()
        {
            RuleFor(c => c.OrderId).GreaterThan(0);
        }
    }
}
