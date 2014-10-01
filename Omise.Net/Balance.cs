using System;
using Newtonsoft.Json;

namespace Omise
{
	[JsonObject]
	public class Balance: ResponseObject
	{
		[JsonProperty("livemode")]
		public string LiveMode{ get; set;}
		[JsonProperty("available")]
		public decimal Available{ get; set;}
		[JsonProperty("total")]
		public decimal Total{ get; set;}
		[JsonProperty("currency")]
		public string Currency{ get; set;}
	}
}

