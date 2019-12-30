using AutoMapper;
using Ordering.Domain.OrderAggregate;

namespace Ordering.Application.Queries.DTO
{
    [AutoMap(typeof(Client), ReverseMap = true)]
    public class ClientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
