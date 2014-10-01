using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
	[JsonObject]
	public class Token: ResponseObject
	{
		[JsonProperty("livemode")]
		public string LiveMode{ get; set;}

		[JsonProperty("location")]
		public string Location{get;set;}

		[JsonProperty("used")]
		public bool Used{ get;set;}

		[JsonIgnore]
		public Card Card{ get; set;}
	}
}

