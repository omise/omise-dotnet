using Newtonsoft.Json;

namespace Omise.Models
{
    /// <summary>
    /// Balance object
    ///
    /// <a href="https://www.omise.co/balance-api">Balance API</a>
    /// </summary>
    public partial class Balance : ModelBase
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("reserve")]
        public long Reserve { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("transferable")]
        public long Transferable { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Balance;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Currency, another.Currency) &&
                object.Equals(this.Reserve, another.Reserve) &&
                object.Equals(this.Total, another.Total) &&
                object.Equals(this.Transferable, another.Transferable) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Currency != default(string)) {
                    hash = hash * 23 + Currency.GetHashCode();
                }
                if (Reserve != default(long)) {
                    hash = hash * 23 + Reserve.GetHashCode();
                }
                if (Total != default(long)) {
                    hash = hash * 23 + Total.GetHashCode();
                }
                if (Transferable != default(long)) {
                    hash = hash * 23 + Transferable.GetHashCode();
                }

                return hash;
            }
        }
    }
}