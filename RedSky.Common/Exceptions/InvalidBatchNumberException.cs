using System;
using System.Runtime.Serialization;

namespace RedSky.Common.Exceptions
{
    public class InvalidBatchNumberException : Exception
    {
        public InvalidBatchNumberException()
        {
        }

        public InvalidBatchNumberException(string message) : base(message)
        {
        }

        public InvalidBatchNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBatchNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}