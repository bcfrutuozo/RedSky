using System;
using System.Runtime.Serialization;

namespace RedSky.Common.Exceptions
{
    public class EntityRelationshipException : Exception
    {
        public EntityRelationshipException()
        {
        }

        public EntityRelationshipException(string message) : base(message)
        {
        }

        public EntityRelationshipException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityRelationshipException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}