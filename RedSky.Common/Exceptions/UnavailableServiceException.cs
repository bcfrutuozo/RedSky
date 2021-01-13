using System;
using System.Runtime.Serialization;

namespace RedSky.Common.Exceptions
{
    public class UnavailableServiceException : Exception
    {
        public UnavailableServiceException()
        {
        }

        public UnavailableServiceException(string message) : base(message)
        {
        }

        public UnavailableServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnavailableServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}