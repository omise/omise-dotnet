using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Omise
{
    /// <summary>
    /// Object defines the collection information containing the pagination information and the actual collections
    /// </summary>
    /// <typeparam name="T">Type of the object in the collection</typeparam>
	[JsonObject]
	public class CollectionResponseObject<T> where T :class
	{
        /// <summary>
        /// Limit numbers of records return
        /// </summary>
		[JsonProperty("limit")]
		public virtual int Limit{get;set;}

        /// <summary>
        /// Start index of records return
        /// </summary>
		[JsonProperty("offset")]
		public virtual int Offset{get;set;}

        /// <summary>
        /// Total numbers of records
        /// </summary>
		[JsonProperty("total")]
		public virtual int Total{get;set;}

        /// <summary>
        /// Start date which the records has scoped
        /// </summary>
		[JsonProperty("from")]
		public virtual DateTime From{get;set;}

        /// <summary>
        /// End date which the records has scoped
        /// </summary>
		[JsonProperty("to")]
		public virtual DateTime To{get;set;}

        /// <summary>
        /// Collection of the records
        /// </summary>
		[JsonIgnore]
		public virtual ICollection<T> Collection{get;set;}

        /// <summary>
        /// The uri which can be used for getting the cards collection
        /// </summary>
		[JsonProperty("location")]
		public virtual string Location{get;set;}
	}
}

