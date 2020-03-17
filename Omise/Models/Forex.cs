using Newtonsoft.Json;

namespace Omise.Models
{
    /// <summary>
    /// Forex object
    ///
    /// <a href="https://www.omise.co/forex-api">Forex API</a>
    /// </summary>
    public partial class Forex : ModelBase
    {
        [JsonProperty("base")]
        public string Base { get; set; }
        [JsonProperty("quote")]
        public string Quote { get; set; }
        [JsonProperty("rate")]
        public float Rate { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Forex;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Base, another.Base) &&
                object.Equals(this.Quote, another.Quote) &&
                object.Equals(this.Rate, another.Rate) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Base != default(string)) {
                    hash = hash * 23 + Base.GetHashCode();
                }
                if (Quote != default(string)) {
                    hash = hash * 23 + Quote.GetHashCode();
                }
                if (Rate != default(float)) {
                    hash = hash * 23 + Rate.GetHashCode();
                }

                return hash;
            }
        }
    }
}