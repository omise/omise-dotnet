using System;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Omise
{
	[Serializable]
	public class ApiErrorObject
	{
		private string location;

		/// <summary>
		/// URL of error documentation.
		/// </summary>
		/// <value>The location.</value>
		public string Location{ 
			get { return location; } 
		}

		/// <summary>
		/// Error code
		/// </summary>
		private string code;
		public string Code{ 
			get { return code; } 
		}

		/// <summary>
		/// Error message
		/// </summary>
		private string message;
		public string Message{ 
			get { return message; } 
		}

		/// <summary>
		/// Raw error message
		/// </summary>
		private string rawMessage;
		public string RawMessage {
			get { return rawMessage; }
		}

		public ApiErrorObject (string resultString)
		{
			rawMessage = resultString;
			try {
				var errorObj = JObject.Parse (resultString);
				location = errorObj ["location"].ToString ();
				code = errorObj ["code"].ToString ();
				message = errorObj ["message"].ToString ();
			} catch {
				message = "Unable to parse error result. See RawMessage for detail.";
			}
		}

		public override string ToString ()
		{
			return message;
		}
	}
}

