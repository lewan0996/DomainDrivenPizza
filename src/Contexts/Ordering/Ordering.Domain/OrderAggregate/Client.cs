using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Shared.Domain;

namespace Ordering.Domain.OrderAggregate
{
    public class Client : ValueObject
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string EmailAddress { get; private set; }

        public string PhoneNumber { get; private set; }

        public Client(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new DomainException(new ArgumentException("First name of a client cannot be empty",
                    nameof(firstName)));
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new DomainException(new ArgumentException("Last name of a client cannot be empty",
                    nameof(lastName)));
            }
            if(!Regex.IsMatch(emailAddress,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase))
            {
                throw new DomainException(new ArgumentException($"Provided email address {emailAddress} is not valid",
                    nameof(emailAddress)));
            }
            if (!Regex.IsMatch(phoneNumber, @"^\d{9}$"))
            {
                throw new DomainException(new ArgumentException($"Provided phone number {phoneNumber} is not valid",
                    nameof(phoneNumber)));
            }

            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return EmailAddress;
        }
    }
}
