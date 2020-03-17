using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class Barcode : ModelBase
    {
        [JsonProperty("image")]
        public Document Image { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Barcode;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Image, another.Image) &&
                object.Equals(this.Type, another.Type) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Image != default(Document)) {
                    hash = hash * 23 + Image.GetHashCode();
                }
                if (Type != default(string)) {
                    hash = hash * 23 + Type.GetHashCode();
                }

                return hash;
            }
        }
    }
}