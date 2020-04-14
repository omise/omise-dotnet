using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class QrCode : ModelBase
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("mfa_provisioning_uri")]
        public string MfaProvisioningUri { get; set; }
        [JsonProperty("secret")]
        public string Secret { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as QrCode;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Email, another.Email) &&
                object.Equals(this.MfaProvisioningUri, another.MfaProvisioningUri) &&
                object.Equals(this.Secret, another.Secret) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Email != default(string)) {
                    hash = hash * 23 + Email.GetHashCode();
                }
                if (MfaProvisioningUri != default(string)) {
                    hash = hash * 23 + MfaProvisioningUri.GetHashCode();
                }
                if (Secret != default(string)) {
                    hash = hash * 23 + Secret.GetHashCode();
                }

                return hash;
            }
        }
    }
}