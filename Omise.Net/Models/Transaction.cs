using System;
using Newtonsoft.Json;

namespace Omise
{
    /// <summary>
    /// Omise Transaction object
    /// </summary>
	[JsonObject]
	public class Transaction: ResponseObject
	{
        /// <summary>
        /// Transaction amount
        /// </summary>
		[JsonProperty("amount")]
		public int Amount{get;set;}

        /// <summary>
        /// Transaction type, credit or debit
        /// </summary>
		[JsonProperty("type")]
		public string Type{get;set;}

        /// <summary>
        /// Transaction currency
        /// </summary>
		[JsonProperty("currency")]
		public string Currency{get;set;}
	}
}

