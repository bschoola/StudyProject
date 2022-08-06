using System;
using System.Runtime.Serialization;

namespace ECommerce.Domain.Exceptions
{
    public class DomainNotFoundException : Exception
    {
        public DomainNotFoundException()
        {
        }

        public DomainNotFoundException(string message) : base(message)
        {
        }

        public DomainNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
