using Newtonsoft.Json;
using System.Collections.Generic;

namespace Omise.Models
{
    public class CreateDisputeDocumentParams : Params
    {
        [JsonProperty("file")]
        public string File { get; set; }
    }

    public class UpdateDisputeParams : Params
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
    }
}