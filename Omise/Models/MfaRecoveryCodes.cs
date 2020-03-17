using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class MfaRecoveryCodes : ModelBase
    {
        [JsonProperty("codes")]
        public List<IDictionary<string, object>> Codes { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as MfaRecoveryCodes;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Codes, another.Codes) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Codes != default(List<IDictionary<string, object>>)) {
                    hash = hash * 23 + Codes.GetHashCode();
                }

                return hash;
            }
        }
    }
}