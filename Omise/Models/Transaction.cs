using Newtonsoft.Json;
using System;

namespace Omise.Models
{
    public partial class Transaction : ModelBase
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("direction")]
        public TransactionDirection Direction { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("origin")]
        public string Origin { get; set; }
        [JsonProperty("transferable_at")]
        public DateTime TransferableAt { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Transaction;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Amount, another.Amount) &&
                object.Equals(this.Currency, another.Currency) &&
                object.Equals(this.Direction, another.Direction) &&
                object.Equals(this.Key, another.Key) &&
                object.Equals(this.Origin, another.Origin) &&
                object.Equals(this.TransferableAt, another.TransferableAt) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Amount != default(long)) {
                    hash = hash * 23 + Amount.GetHashCode();
                }
                if (Currency != default(string)) {
                    hash = hash * 23 + Currency.GetHashCode();
                }
                if (Direction != default(TransactionDirection)) {
                    hash = hash * 23 + Direction.GetHashCode();
                }
                if (Key != default(string)) {
                    hash = hash * 23 + Key.GetHashCode();
                }
                if (Origin != default(string)) {
                    hash = hash * 23 + Origin.GetHashCode();
                }
                if (TransferableAt != default(DateTime)) {
                    hash = hash * 23 + TransferableAt.GetHashCode();
                }

                return hash;
            }
        }
    }
}