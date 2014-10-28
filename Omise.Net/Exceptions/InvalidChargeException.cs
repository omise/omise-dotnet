using System;
using System.Security.Permissions;
using System.Runtime.Serialization;

namespace Omise
{
    /// <summary>
    /// Invalid charge exception. The exception will be thrown when charge validation fails.
    /// </summary>
    [Serializable]
    public sealed class InvalidChargeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.InvalidChargeException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public InvalidChargeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.InvalidChargeException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvalidChargeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        private InvalidChargeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

