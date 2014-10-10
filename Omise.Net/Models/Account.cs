using System;
using Newtonsoft.Json;

namespace Omise
{
    /// <summary>
    /// Omise account object
    /// </summary>
	[JsonObject]
	public class Account: ResponseObject
	{
        /// <summary>
        /// The email address of the account
        /// </summary>
		[JsonProperty("email")]
		public string Email{ get; set;}
	}
}

