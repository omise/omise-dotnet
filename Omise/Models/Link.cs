using Newtonsoft.Json;
using System;

namespace Omise.Models
{
    /// <summary>
    /// Links object
    ///
    /// <a href="https://www.omise.co/links-api">Links API</a>
    /// </summary>
    public partial class Link : ModelBase
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("charges")]
        public ScopedList<Charge> Charges { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("multiple")]
        public bool Multiple { get; set; }
        [JsonProperty("payment_uri")]
        public string PaymentURI { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("used")]
        public bool Used { get; set; }
        [JsonProperty("used_at")]
        public DateTime UsedAt { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Link;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Amount, another.Amount) &&
                object.Equals(this.Charges, another.Charges) &&
                object.Equals(this.Currency, another.Currency) &&
                object.Equals(this.Description, another.Description) &&
                object.Equals(this.Multiple, another.Multiple) &&
                object.Equals(this.PaymentURI, another.PaymentURI) &&
                object.Equals(this.Title, another.Title) &&
                object.Equals(this.Used, another.Used) &&
                object.Equals(this.UsedAt, another.UsedAt) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Amount != default(long)) {
                    hash = hash * 23 + Amount.GetHashCode();
                }
                if (Charges != default(ScopedList<Charge>)) {
                    hash = hash * 23 + Charges.GetHashCode();
                }
                if (Currency != default(string)) {
                    hash = hash * 23 + Currency.GetHashCode();
                }
                if (Description != default(string)) {
                    hash = hash * 23 + Description.GetHashCode();
                }
                if (Multiple != default(bool)) {
                    hash = hash * 23 + Multiple.GetHashCode();
                }
                if (PaymentURI != default(string)) {
                    hash = hash * 23 + PaymentURI.GetHashCode();
                }
                if (Title != default(string)) {
                    hash = hash * 23 + Title.GetHashCode();
                }
                if (Used != default(bool)) {
                    hash = hash * 23 + Used.GetHashCode();
                }
                if (UsedAt != default(DateTime)) {
                    hash = hash * 23 + UsedAt.GetHashCode();
                }

                return hash;
            }
        }
    }

    public class CreateLinkParams : Request
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("multiple")]
        public bool Multiple { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}