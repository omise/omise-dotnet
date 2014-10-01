using System;
using Newtonsoft.Json;

namespace Omise
{
	[JsonObject]
	public class Charge : ResponseObject
	{
		[JsonProperty("livemode")]
		public bool LiveMode{get;set;}
		[JsonProperty("location")]
		public string Location{get;set;}
		[JsonProperty("amount")]
		public int Amount{ get; set; }
		[JsonProperty("currency")]
		public string Currency{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("capture")]
		public bool Capture{get;set;}
		[JsonProperty("authorized")]
		public bool Authorized{get;set;}
		[JsonProperty("captured")]
		public bool Captured{get;set;}
		[JsonProperty("return_uri")]
		public string ReturnUri{ get; set; }
		[JsonProperty("reference")]
		public string Reference{ get; set; }
		[JsonProperty("authorize_uri")]
		public string AuthorizeUrl{ get;set; } 
		[JsonProperty("customer")]
		public string CustomerId{ get; set; }
		[JsonProperty("ip")]
		public string Ip{get;set;}

		public Card Card{ get; set; }
	}
}

