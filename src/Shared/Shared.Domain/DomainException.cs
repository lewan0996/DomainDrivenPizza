using System;

namespace Shared.Domain
{
    public class DomainException : Exception, IDomainException
    {
        public DomainException() { }
        public DomainException(string message) : base(message) { }
        public DomainException(string message, Exception innerException) : base(message, innerException) { }
        public DomainException(Exception innerException) : base(innerException.Message, innerException) { }
    }
}
