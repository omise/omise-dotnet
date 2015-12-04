using System;
using Newtonsoft.Json;

namespace Omise.Models {
    /// <summary>
    /// Omise Bank account object
    /// </summary>
    [JsonObject]
    public class BankAccount: ResponseObject {
        [JsonProperty("brand")]
        public string Brand{ get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("last_digits")]
        public string LastDigits { get; set; }
    }
}

