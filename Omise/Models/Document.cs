using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class Document : ModelBase
    {
        [JsonProperty("download_uri")]
        public string DownloadUri { get; set; }
        [JsonProperty("filename")]
        public string Filename { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Document;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.DownloadUri, another.DownloadUri) &&
                object.Equals(this.Filename, another.Filename) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (DownloadUri != default(string)) {
                    hash = hash * 23 + DownloadUri.GetHashCode();
                }
                if (Filename != default(string)) {
                    hash = hash * 23 + Filename.GetHashCode();
                }

                return hash;
            }
        }
    }
}