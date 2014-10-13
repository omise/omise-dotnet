using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Omise
{
    /// <summary>
    /// Invalid card exception. The exception will be thrown when the card validation fails.
    /// </summary>
    [Serializable]
    public sealed class InvalidCardException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.InvalidCardException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public InvalidCardException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.InvalidCardException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvalidCardException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        private InvalidCardException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

