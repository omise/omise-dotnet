using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class Chain : ModelBase
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("revoked")]
        public bool Revoked { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Chain;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Email, another.Email) &&
                object.Equals(this.Key, another.Key) &&
                object.Equals(this.Revoked, another.Revoked) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Email != default(string)) {
                    hash = hash * 23 + Email.GetHashCode();
                }
                if (Key != default(string)) {
                    hash = hash * 23 + Key.GetHashCode();
                }
                if (Revoked != default(bool)) {
                    hash = hash * 23 + Revoked.GetHashCode();
                }

                return hash;
            }
        }
    }
}