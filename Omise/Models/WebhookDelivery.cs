using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class WebhookDelivery : ModelBase
    {
        [JsonProperty("status")]
        public long Status { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as WebhookDelivery;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Status, another.Status) &&
                object.Equals(this.Uri, another.Uri) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Status != default(long)) {
                    hash = hash * 23 + Status.GetHashCode();
                }
                if (Uri != default(string)) {
                    hash = hash * 23 + Uri.GetHashCode();
                }

                return hash;
            }
        }
    }
}