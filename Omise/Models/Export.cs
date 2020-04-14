using Newtonsoft.Json;
using System.Collections.Generic;

namespace Omise.Models
{
    public partial class Export : ModelBase
    {
        [JsonProperty("download_uri")]
        public string DownloadUri { get; set; }
        [JsonProperty("file_type")]
        public string FileType { get; set; }
        [JsonProperty("filter_params")]
        public IDictionary<string, object> FilterParams { get; set; }
        [JsonProperty("filter_type")]
        public string FilterType { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("object_type")]
        public string ObjectType { get; set; }
        [JsonProperty("rows")]
        public long Rows { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("team")]
        public string Team { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Export;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.DownloadUri, another.DownloadUri) &&
                object.Equals(this.FileType, another.FileType) &&
                object.Equals(this.FilterParams, another.FilterParams) &&
                object.Equals(this.FilterType, another.FilterType) &&
                object.Equals(this.Name, another.Name) &&
                object.Equals(this.ObjectType, another.ObjectType) &&
                object.Equals(this.Rows, another.Rows) &&
                object.Equals(this.Status, another.Status) &&
                object.Equals(this.Team, another.Team) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (DownloadUri != default(string)) {
                    hash = hash * 23 + DownloadUri.GetHashCode();
                }
                if (FileType != default(string)) {
                    hash = hash * 23 + FileType.GetHashCode();
                }
                if (FilterParams != default(IDictionary<string, object>)) {
                    hash = hash * 23 + FilterParams.GetHashCode();
                }
                if (FilterType != default(string)) {
                    hash = hash * 23 + FilterType.GetHashCode();
                }
                if (Name != default(string)) {
                    hash = hash * 23 + Name.GetHashCode();
                }
                if (ObjectType != default(string)) {
                    hash = hash * 23 + ObjectType.GetHashCode();
                }
                if (Rows != default(long)) {
                    hash = hash * 23 + Rows.GetHashCode();
                }
                if (Status != default(string)) {
                    hash = hash * 23 + Status.GetHashCode();
                }
                if (Team != default(string)) {
                    hash = hash * 23 + Team.GetHashCode();
                }

                return hash;
            }
        }
    }
}