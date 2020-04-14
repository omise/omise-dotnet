using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class PlatformFee : ModelBase
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("fixed")]
        public long Fixed { get; set; }
        [JsonProperty("percentage")]
        public float Percentage { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as PlatformFee;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Amount, another.Amount) &&
                object.Equals(this.Fixed, another.Fixed) &&
                object.Equals(this.Percentage, another.Percentage) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Amount != default(long)) {
                    hash = hash * 23 + Amount.GetHashCode();
                }
                if (Fixed != default(long)) {
                    hash = hash * 23 + Fixed.GetHashCode();
                }
                if (Percentage != default(float)) {
                    hash = hash * 23 + Percentage.GetHashCode();
                }

                return hash;
            }
        }
    }
}