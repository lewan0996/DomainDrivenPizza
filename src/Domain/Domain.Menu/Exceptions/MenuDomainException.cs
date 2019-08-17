using System;

namespace Domain.Menu.Exceptions
{
    public class MenuDomainException : Exception
    {
        public MenuDomainException()
        {
        }

        public MenuDomainException(string message): base(message)
        {
        }

        public MenuDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
