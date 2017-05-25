using System;
using Newtonsoft.Json;

namespace Omise
{
    [JsonObject]
    public class ScopedList<T> : ListBase<T>
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("from")]
        public DateTime From { get; set; }

        [JsonProperty("to")]
        public DateTime To { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}