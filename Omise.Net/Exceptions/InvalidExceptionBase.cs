using System;
using System.Security.Permissions;
using System.Runtime.Serialization;

namespace Omise
{
	/// <summary>
	/// Invalid exception base.
	/// </summary>
	[Serializable]
	public class InvalidExceptionBase : Exception
	{
		public InvalidExceptionBase(string message): base(message)
		{
		}

		public InvalidExceptionBase(string message, Exception innerException): base(message, innerException)
		{
		}

		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		private InvalidExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}

