using System;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Omise
{
	public class ApiErrorObject
	{
		private string rawMessage;
		public string Location{ get; set;}
		public string Code{ get; set;}
		public string Message{ get; set;}
		public string RawMessage {
			get {
				return rawMessage;
			}
		}

		public ApiErrorObject (string resultString)
		{
			rawMessage = resultString;
			try{
				JObject errorObj = JObject.Parse (resultString);
				Location = errorObj ["location"].ToString();
				Code = errorObj ["code"].ToString();
				Message = errorObj ["message"].ToString();
			}catch{
				Message = "Unable to parse error result. See RawMessage for detail.";
			}
		}

		public override string ToString ()
		{
			return Message;
		}
	}
}

