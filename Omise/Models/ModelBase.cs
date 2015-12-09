using System;
using Newtonsoft.Json;

namespace Omise.Models {
    public abstract class ModelBase {
        [JsonIgnore]
        public IRequester Requester { get; internal set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}

