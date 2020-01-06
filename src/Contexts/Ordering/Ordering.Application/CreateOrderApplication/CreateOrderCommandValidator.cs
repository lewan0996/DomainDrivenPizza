using FluentValidation;

namespace Ordering.Application.CreateOrderApplication
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(c => c.ClientFirstName).NotEmpty();
            RuleFor(c => c.ClientLastName).NotEmpty();
            RuleFor(c => c.ClientEmailAddress).NotEmpty().EmailAddress();
            RuleFor(c => c.ClientPhoneNumber).NotEmpty().Matches(@"^\d{9}$");
            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.AddressLine1).NotEmpty();
            RuleFor(c => c.AddressLine2).NotEmpty();
            RuleFor(c => c.ZipCode).NotEmpty();
        }
    }
}
