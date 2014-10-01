using System;

namespace Omise
{
	public class InvalidExceptionBase : Exception
	{
		public InvalidExceptionBase(string message): base(message)
		{
		}

		public InvalidExceptionBase(string message, Exception innerException): base(message, innerException)
		{
		}
	}
}

