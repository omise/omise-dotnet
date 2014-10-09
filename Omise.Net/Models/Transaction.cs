using System;
using Newtonsoft.Json;

namespace Omise
{
	[JsonObject]
	public class Transaction: ResponseObject
	{
		[JsonProperty("amount")]
		public int Amount{get;set;}

		[JsonProperty("type")]
		public string Type{get;set;}

		[JsonProperty("currency")]
		public string Currency{get;set;}
	}
}

