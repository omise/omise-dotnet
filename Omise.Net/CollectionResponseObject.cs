using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Omise
{
	[JsonObject]
	public class CollectionResponseObject<T> where T :class
	{
		[JsonProperty("limit")]
		public virtual int Limit{get;set;}

		[JsonProperty("offset")]
		public virtual int Offset{get;set;}

		[JsonProperty("total")]
		public virtual int Total{get;set;}

		[JsonProperty("from")]
		public virtual DateTime From{get;set;}

		[JsonProperty("to")]
		public virtual DateTime To{get;set;}

		[JsonIgnore]
		public virtual ICollection<T> Collection{get;set;}

		[JsonProperty("location")]
		public virtual string Location{get;set;}
	}
}

