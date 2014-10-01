using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Omise
{
	[JsonObject]
	public class Customer: ResponseObject
	{
		[JsonProperty("email")]
		public string Email{get;set;}
		[JsonProperty("description")]
		public string Description{ get; set;}
		[JsonProperty("livemode")]
		public bool LiveMode{get;set;}
		[JsonProperty("deleted")]
		public bool Deleted{ get; set;}
		[JsonProperty("location")]
		public string Location{get;set;}
		[JsonProperty("default_card")]
		public string DefaultCardId{ get; set;}

		[JsonIgnore]
		public ICollection<Card> Cards{ get; set; }
	}
}

