using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class SystemInfo : ModelBase
    {
        [JsonProperty("versions")]
        public List<string> Versions { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as SystemInfo;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Versions, another.Versions) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Versions != default(List<string>)) {
                    hash = hash * 23 + Versions.GetHashCode();
                }

                return hash;
            }
        }
    }
}