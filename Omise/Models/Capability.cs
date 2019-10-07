using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class Capability : ModelBase
    {
        [JsonProperty("banks")]
        public List<string> Banks { get; set; }
        [JsonProperty("payment_methods")]
        public List<PaymentMethod> PaymentMethods { get; set; }
        [JsonProperty("zero_interest_installments")]
        public bool ZeroInterestInstallments { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Capability;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Banks, another.Banks) &&
                object.Equals(this.PaymentMethods, another.PaymentMethods) &&
                object.Equals(this.ZeroInterestInstallments, another.ZeroInterestInstallments) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Banks != default(List<string>)) {
                    hash = hash * 23 + Banks.GetHashCode();
                }
                if (PaymentMethods != default(List<PaymentMethod>)) {
                    hash = hash * 23 + PaymentMethods.GetHashCode();
                }
                if (ZeroInterestInstallments != default(bool)) {
                    hash = hash * 23 + ZeroInterestInstallments.GetHashCode();
                }

                return hash;
            }
        }
    }
}