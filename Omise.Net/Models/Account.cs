using System;
using Newtonsoft.Json;

namespace Omise
{
	[JsonObject]
	public class Account: ResponseObject
	{
		[JsonProperty("email")]
		public string Email{ get; set;}
	}
}

