using System;
using Newtonsoft.Json;

namespace Omise
{
    /// <summary>
    /// Represents result of deleting an object
    /// </summary>
    [JsonObject]
    public class DeleteResponseObject
    {
        /// <summary>
        /// Type of the object that has been deleted
        /// </summary>
        [JsonProperty("object")]
        public string ObjectType { get; set; }

        /// <summary>
        /// Id of the object that has been deleted
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Defines whether the deleted object was in live mode
        /// </summary>
        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        /// <summary>
        /// Defines whether the object has been deleted
        /// </summary>
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}

