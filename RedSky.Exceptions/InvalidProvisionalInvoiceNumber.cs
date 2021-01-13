using System;

namespace RedSky.Exceptions
{
    public class InvalidProvisionalInvoiceNumberException : Exception
    {
        public InvalidProvisionalInvoiceNumberException() : base() { }

        public InvalidProvisionalInvoiceNumberException(string message) : base(message) { }

        public InvalidProvisionalInvoiceNumberException(string message, Exception innerException) : base(message, innerException) { }
    }
}
