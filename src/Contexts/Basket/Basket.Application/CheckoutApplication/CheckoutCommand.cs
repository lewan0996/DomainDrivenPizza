using MediatR;

namespace Basket.Application.CheckoutApplication
{
    public class CheckoutCommand : IRequest
    {
        public CheckoutCommand(int basketId, string firstName, string lastName, string emailAddress, string phoneNumber,
            string city, string addressLine1, string addressLine2, short zipCode)
        {
            BasketId = basketId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            City = city;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            ZipCode = zipCode;
        }

        public int BasketId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
        public string PhoneNumber { get; }
        public string City { get; }
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public short ZipCode { get; }
    }
}
