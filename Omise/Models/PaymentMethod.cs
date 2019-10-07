using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class PaymentMethod : ModelBase
    {
        [JsonProperty("card_brands")]
        public List<string> CardBrands { get; set; }
        [JsonProperty("currencies")]
        public List<string> Currencies { get; set; }
        [JsonProperty("installment_terms")]
        public List<long> InstallmentTerms { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as PaymentMethod;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.CardBrands, another.CardBrands) &&
                object.Equals(this.Currencies, another.Currencies) &&
                object.Equals(this.InstallmentTerms, another.InstallmentTerms) &&
                object.Equals(this.Name, another.Name) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (CardBrands != default(List<string>)) {
                    hash = hash * 23 + CardBrands.GetHashCode();
                }
                if (Currencies != default(List<string>)) {
                    hash = hash * 23 + Currencies.GetHashCode();
                }
                if (InstallmentTerms != default(List<long>)) {
                    hash = hash * 23 + InstallmentTerms.GetHashCode();
                }
                if (Name != default(string)) {
                    hash = hash * 23 + Name.GetHashCode();
                }

                return hash;
            }
        }
    }
}