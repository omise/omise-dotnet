using System;
using Newtonsoft.Json;

namespace Omise
{
	public abstract class ResponseObject
	{
		[JsonProperty("id")]
		public virtual string Id{ get; set;}
		[JsonProperty("created")]
		public virtual DateTime CreatedAt{ get; set;}
	}
}

