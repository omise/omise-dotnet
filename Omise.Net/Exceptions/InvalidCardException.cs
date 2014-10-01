using System;

namespace Omise
{
	public class InvalidCardException: InvalidExceptionBase
	{
		public InvalidCardException(string message): base(message)
		{
		}

		public InvalidCardException(string message, Exception innerException): base(message, innerException)
		{
		}
	}
}

