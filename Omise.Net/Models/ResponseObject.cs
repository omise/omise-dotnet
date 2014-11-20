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
        public virtual string Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the object is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        [JsonProperty("deleted")]
        public virtual bool Deleted{ get; set; }

        /// <summary>
        /// Specify the creation datetime of the object
        /// </summary>
        [JsonProperty("created")]
        public virtual DateTime CreatedAt { get; set; }
    }
}

