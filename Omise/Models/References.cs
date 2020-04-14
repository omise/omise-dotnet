using Newtonsoft.Json;
using System;

namespace Omise.Models
{
    public partial class References : ModelBase {
        [JsonProperty("barcode")]
        public string Barcode { get; set; }
        [JsonProperty("customer_amount")]
        public long CustomerAmount { get; set; }
        [JsonProperty("customer_currency")]
        public string CustomerCurrency { get; set; }
        [JsonProperty("customer_exchange_rate")]
        public float CustomerExchangeRate { get; set; }
        [JsonProperty("device_id")]
        public string DeviceId { get; set; }
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }
        [JsonProperty("omise_tax_id")]
        public string OmiseTaxId { get; set; }
        [JsonProperty("payment_code")]
        public string PaymentCode { get; set; }
        [JsonProperty("reference_number_1")]
        public string ReferenceNumber1 { get; set; }
        [JsonProperty("reference_number_2")]
        public string ReferenceNumber2 { get; set; }
        [JsonProperty("va_code")]
        public string VaCode { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as References;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Barcode, another.Barcode) &&
                object.Equals(this.CustomerAmount, another.CustomerAmount) &&
                object.Equals(this.CustomerCurrency, another.CustomerCurrency) &&
                object.Equals(this.CustomerExchangeRate, another.CustomerExchangeRate) &&
                object.Equals(this.DeviceId, another.DeviceId) &&
                object.Equals(this.ExpiresAt, another.ExpiresAt) &&
                object.Equals(this.OmiseTaxId, another.OmiseTaxId) &&
                object.Equals(this.PaymentCode, another.PaymentCode) &&
                object.Equals(this.ReferenceNumber1, another.ReferenceNumber1) &&
                object.Equals(this.ReferenceNumber2, another.ReferenceNumber2) &&
                object.Equals(this.VaCode, another.VaCode) &&
                true;
        }

        public override int GetHashCode() {
            unchecked {
                int hash = 17;
                if (Barcode != default(string)) {
                    hash = hash * 23 + Barcode.GetHashCode();
                }
                if (CustomerAmount != default(long)) {
                    hash = hash * 23 + CustomerAmount.GetHashCode();
                }
                if (CustomerCurrency != default(string)) {
                    hash = hash * 23 + CustomerCurrency.GetHashCode();
                }
                if (CustomerExchangeRate != default(float)) {
                    hash = hash * 23 + CustomerExchangeRate.GetHashCode();
                }
                if (DeviceId != default(string)) {
                    hash = hash * 23 + DeviceId.GetHashCode();
                }
                if (ExpiresAt != default(DateTime)) {
                    hash = hash * 23 + ExpiresAt.GetHashCode();
                }
                if (OmiseTaxId != default(string)) {
                    hash = hash * 23 + OmiseTaxId.GetHashCode();
                }
                if (PaymentCode != default(string)) {
                    hash = hash * 23 + PaymentCode.GetHashCode();
                }
                if (ReferenceNumber1 != default(string)) {
                    hash = hash * 23 + ReferenceNumber1.GetHashCode();
                }
                if (ReferenceNumber2 != default(string)) {
                    hash = hash * 23 + ReferenceNumber2.GetHashCode();
                }
                if (VaCode != default(string)) {
                    hash = hash * 23 + VaCode.GetHashCode();
                }

                return hash;
            }
        }
    }
}