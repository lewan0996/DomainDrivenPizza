using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Domain.SharedKernel;

namespace Domain.Ordering.OrderAggregate
{
    public class Client : ValueObject
    {
        private string _firstName;
        public string FirstName => _firstName;

        private string _lastName;
        public string LastName => _lastName;

        private string _emailAddress;
        public string EmailAddress => _emailAddress;

        private string _phoneNumber;
        public string PhoneNumber => _phoneNumber;

        public Client(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name of a client cannot be empty", nameof(firstName));
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name of a client cannot be empty", nameof(lastName));
            }
            if(!Regex.IsMatch(emailAddress,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase))
            {
                throw new ArgumentException($"Provided email address {emailAddress} is not valid",
                    nameof(emailAddress));
            }
            if (!Regex.IsMatch(phoneNumber, @"^(\+[0-9]{9})$"))
            {
                throw new ArgumentException($"Provided phone number {phoneNumber} is not valid", nameof(phoneNumber));
            }

            _firstName = firstName;
            _lastName = lastName;
            _emailAddress = emailAddress;
            _phoneNumber = phoneNumber;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _emailAddress;
        }
    }
}
