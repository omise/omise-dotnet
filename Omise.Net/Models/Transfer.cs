using System;
using Newtonsoft.Json;

namespace Omise
{
	[JsonObject]
	public class Transfer: ResponseObject
	{
		[JsonProperty("amount")]
		public decimal Amount{get;set;}
		[JsonProperty("currency")]
		public string Currency{get;set;}
	}
}

