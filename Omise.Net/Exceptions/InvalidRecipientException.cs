using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Omise
{
    /// <summary>
    /// Invalid recipient exception. The exception will be thrown when recipient validation fails.
    /// </summary>
    [Serializable]
    public sealed class InvalidRecipientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.InvalidCustomerException"/> class with the message.
        /// </summary>
        /// <param name="message">Message.</param>
        public InvalidRecipientException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.InvalidCustomerException"/> class with the message and inner exception object.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvalidRecipientException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        private InvalidRecipientException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

