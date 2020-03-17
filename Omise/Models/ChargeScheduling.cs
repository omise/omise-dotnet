using Newtonsoft.Json;
using System.Collections.Generic;

namespace Omise.Models
{
    /// <summary>
    /// Charge Schedule object
    ///
    /// <a href="https://www.omise.co/charge-schedules-api">Charge Schedule API</a>
    /// </summary>
    public partial class ChargeScheduling
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("card")]
        public string Card { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("customer")]
        public string Customer { get; set; }
        [JsonProperty("default_card")]
        public bool DefaultCard { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
    }
}