using System;

namespace Omise
{
	public class InvalidCredentialException: Exception
	{
		static string defaultMessage = "Invalid credential.";
		public InvalidCredentialException():base(defaultMessage)
		{

		}

		public InvalidCredentialException (string  message): base(message)
		{
		}

		public InvalidCredentialException(string message, Exception innerException): base(message, innerException)
		{
		}
	}
}

