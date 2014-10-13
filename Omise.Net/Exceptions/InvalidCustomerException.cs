using System;
using System.Security.Permissions;
using System.Runtime.Serialization;

namespace Omise
{
    /// <summary>
    /// Invalid customer exception. The exception will be thrown when customer validation fails.
    /// </summary>
    [Serializable]
    public sealed class InvalidCustomerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.InvalidCustomerException"/> class with the message.
        /// </summary>
        /// <param name="message">Message.</param>
        public InvalidCustomerException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.InvalidCustomerException"/> class with the message and inner exception object.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvalidCustomerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        private InvalidCustomerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}