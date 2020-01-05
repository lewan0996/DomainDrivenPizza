using AutoMapper;
using Shared.Domain.ValueObjects;

namespace Ordering.Application.Queries.DTO
{
    [AutoMap(typeof(Address), ReverseMap = true)]
    public class AddressDTO
    {
        public string City { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
    }
}
