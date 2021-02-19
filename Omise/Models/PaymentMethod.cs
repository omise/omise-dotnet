using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise.Models
{
    public class PaymentMethod
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("currencies")]
        public List<string> Currencies { get; set; }

        [JsonProperty("card_brands")]
        public List<string> CardBrands { get; set; }

        [JsonProperty("installment_terms")]
        public List<int> InstallmentTerms { get; set; }

        [JsonProperty("banks")]
        public List<Bank> Banks { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as PaymentMethod;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Object, another.Object) &&
                object.Equals(this.Name, another.Name) &&
                object.Equals(this.Currencies, another.Currencies) &&
                object.Equals(this.CardBrands, another.CardBrands) &&
                object.Equals(this.InstallmentTerms, another.InstallmentTerms) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Object.GetHashCode();
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Currencies.GetHashCode();
                hash = hash * 23 + CardBrands.GetHashCode();
                hash = hash * 23 + InstallmentTerms.GetHashCode();

                return hash;
            }
        }
    }
}
