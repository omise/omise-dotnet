using Newtonsoft.Json;
using System.Collections.Generic;

namespace Omise.Models
{
    /// <summary>
    /// Refund object
    ///
    /// <a href="https://www.omise.co/refunds-api">Refund API</a>
    /// </summary>
    public partial class Refund : ModelBase
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("charge")]
        public string Charge { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("funding_amount")]
        public long FundingAmount { get; set; }
        [JsonProperty("funding_currency")]
        public string FundingCurrency { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
        [JsonProperty("status")]
        public RefundStatus Status { get; set; }
        [JsonProperty("transaction")]
        public string Transaction { get; set; }
        [JsonProperty("voided")]
        public bool Voided { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Refund;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Amount, another.Amount) &&
                object.Equals(this.Charge, another.Charge) &&
                object.Equals(this.Currency, another.Currency) &&
                object.Equals(this.FundingAmount, another.FundingAmount) &&
                object.Equals(this.FundingCurrency, another.FundingCurrency) &&
                object.Equals(this.Metadata, another.Metadata) &&
                object.Equals(this.Status, another.Status) &&
                object.Equals(this.Transaction, another.Transaction) &&
                object.Equals(this.Voided, another.Voided) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Amount != default(long)) {
                    hash = hash * 23 + Amount.GetHashCode();
                }
                if (Charge != default(string)) {
                    hash = hash * 23 + Charge.GetHashCode();
                }
                if (Currency != default(string)) {
                    hash = hash * 23 + Currency.GetHashCode();
                }
                if (FundingAmount != default(long)) {
                    hash = hash * 23 + FundingAmount.GetHashCode();
                }
                if (FundingCurrency != default(string)) {
                    hash = hash * 23 + FundingCurrency.GetHashCode();
                }
                if (Metadata != default(IDictionary<string, object>)) {
                    hash = hash * 23 + Metadata.GetHashCode();
                }
                if (Status != default(RefundStatus)) {
                    hash = hash * 23 + Status.GetHashCode();
                }
                if (Transaction != default(string)) {
                    hash = hash * 23 + Transaction.GetHashCode();
                }
                if (Voided != default(bool)) {
                    hash = hash * 23 + Voided.GetHashCode();
                }

                return hash;
            }
        }
    }
}