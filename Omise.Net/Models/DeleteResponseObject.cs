using System;
using Newtonsoft.Json;

namespace Omise
{
	[JsonObject]
	public class DeleteResponseObject
	{
		[JsonProperty("object")]
		public string ObjectType{get;set;}
		[JsonProperty("id")]
		public string Id{get;set;}
		[JsonProperty("livemode")]
		public bool LiveMode{get;set;}
		[JsonProperty("deleted")]
		public bool Deleted{get;set;}
	}
}

