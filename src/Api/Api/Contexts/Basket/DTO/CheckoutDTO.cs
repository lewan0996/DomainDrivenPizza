using AutoMapper;
using Basket.Application.CheckoutApplication;

#pragma warning disable 1591
namespace API.Contexts.Basket.DTO
{
    [AutoMap(typeof(CheckoutCommand), ReverseMap = true)]
    public class CheckoutDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public short ZipCode { get; set; }
    }
}
