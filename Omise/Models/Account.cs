using Newtonsoft.Json;
using System.Collections.Generic;

namespace Omise.Models
{
    /// <summary>
    /// Account object
    ///
    /// <a href="https://www.omise.co/account-api">Account API</a>
    /// </summary>
    public partial class Account : ModelBase
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("supported_currencies")]
        public List<string> SupportedCurrencies { get; set; }
        [JsonProperty("team")]
        public string Team { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Account;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Country, another.Country) &&
                object.Equals(this.Currency, another.Currency) &&
                object.Equals(this.Email, another.Email) &&
                object.Equals(this.SupportedCurrencies, another.SupportedCurrencies) &&
                object.Equals(this.Team, another.Team) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Country != default(string)) {
                    hash = hash * 23 + Country.GetHashCode();
                }
                if (Currency != default(string)) {
                    hash = hash * 23 + Currency.GetHashCode();
                }
                if (Email != default(string)) {
                    hash = hash * 23 + Email.GetHashCode();
                }
                if (SupportedCurrencies != default(List<string>)) {
                    hash = hash * 23 + SupportedCurrencies.GetHashCode();
                }
                if (Team != default(string)) {
                    hash = hash * 23 + Team.GetHashCode();
                }

                return hash;
            }
        }
    }
}