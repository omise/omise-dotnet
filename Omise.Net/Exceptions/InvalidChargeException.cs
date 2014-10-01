using System;

namespace Omise
{
	public class InvalidChargeException: InvalidExceptionBase
	{
		public InvalidChargeException(string message): base(message)
		{
		}

		public InvalidChargeException(string message, Exception innerException): base(message, innerException)
		{
		}
	}
}

