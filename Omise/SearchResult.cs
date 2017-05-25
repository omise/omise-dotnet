using System.Collections.Generic;
using Newtonsoft.Json;
using Omise.Models;

namespace Omise
{
    [JsonObject]
    public class SearchResult<T> : ListBase<T>
    {
        [JsonProperty("scope")]
        public SearchScope Scope { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("filters")]
        public IDictionary<string, string> Filters { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}

