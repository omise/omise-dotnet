using System;
using Newtonsoft.Json;

namespace Omise.Models {
    public class ResponseObject {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}

