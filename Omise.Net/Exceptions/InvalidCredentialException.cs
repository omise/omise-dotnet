using System;
using System.Security.Permissions;
using System.Runtime.Serialization;

namespace Omise
{
	/// <summary>
	/// Invalid credential exception. The exception will be thrown when the Api request is not authorized.
	/// </summary>
	[Serializable]
	public sealed class InvalidCredentialException: Exception
	{
		static string defaultMessage = "Invalid credential.";
		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.InvalidCredentialException"/> class.
		/// </summary>
		public InvalidCredentialException():base(defaultMessage)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.InvalidCredentialException"/> class.
		/// </summary>
		/// <param name="message">Message.</param>
		public InvalidCredentialException (string  message): base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.InvalidCredentialException"/> class.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="innerException">Inner exception.</param>
		public InvalidCredentialException(string message, Exception innerException): base(message, innerException)
		{
		}

		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		private InvalidCredentialException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}

