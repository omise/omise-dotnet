using System;
using Newtonsoft.Json;

namespace Omise
{
    /// <summary>
    /// An abstract class used as a base class for all response of the api
    /// </summary>
	public abstract class ResponseObject
	{
        /// <summary>
        /// Id of the response object
        /// </summary>
		[JsonProperty("id")]
		public virtual string Id{ get; set;}

        /// <summary>
        /// Specify the creation datetime of the object
        /// </summary>
		[JsonProperty("created")]
		public virtual DateTime CreatedAt{ get; set;}
	}
}

