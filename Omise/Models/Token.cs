using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class Token : ModelBase
    {
        [JsonProperty("card")]
        public Card Card { get; set; }
        [JsonProperty("used")]
        public bool Used { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Token;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Card, another.Card) &&
                object.Equals(this.Used, another.Used) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Card != default(Card)) {
                    hash = hash * 23 + Card.GetHashCode();
                }
                if (Used != default(bool)) {
                    hash = hash * 23 + Used.GetHashCode();
                }

                return hash;
            }
        }
    }

    public class CreateTokenParams : Request
    {
        [JsonProperty("card")]
        public Card Card { get; set; }
    }
}