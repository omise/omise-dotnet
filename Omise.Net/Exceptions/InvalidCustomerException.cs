using System;

namespace Omise
{
	public class InvalidCustomerException: InvalidExceptionBase
	{
		public InvalidCustomerException(string message): base(message)
		{
		}

		public InvalidCustomerException(string message, Exception innerException): base(message, innerException)
		{
		}
	}
}