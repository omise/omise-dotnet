using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Omise.Models
{
    /// <summary>
    /// Dispute object
    ///
    /// <a href="https://www.omise.co/disputes-api">Dispute API</a>
    /// </summary>
    public partial class Dispute : ModelBase
    {
        [JsonProperty("admin_message")]
        public string AdminMessage { get; set; }
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("charge")]
        public string Charge { get; set; }
        [JsonProperty("closed_at")]
        public DateTime ClosedAt { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("documents")]
        public ScopedList<Document> Documents { get; set; }
        [JsonProperty("funding_amount")]
        public long FundingAmount { get; set; }
        [JsonProperty("funding_currency")]
        public string FundingCurrency { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
        [JsonProperty("reason_code")]
        public DisputeReasonCode ReasonCode { get; set; }
        [JsonProperty("reason_message")]
        public string ReasonMessage { get; set; }
        [JsonProperty("status")]
        public DisputeStatus Status { get; set; }
        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Dispute;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.AdminMessage, another.AdminMessage) &&
                object.Equals(this.Amount, another.Amount) &&
                object.Equals(this.Charge, another.Charge) &&
                object.Equals(this.ClosedAt, another.ClosedAt) &&
                object.Equals(this.Currency, another.Currency) &&
                object.Equals(this.Documents, another.Documents) &&
                object.Equals(this.FundingAmount, another.FundingAmount) &&
                object.Equals(this.FundingCurrency, another.FundingCurrency) &&
                object.Equals(this.Message, another.Message) &&
                object.Equals(this.Metadata, another.Metadata) &&
                object.Equals(this.ReasonCode, another.ReasonCode) &&
                object.Equals(this.ReasonMessage, another.ReasonMessage) &&
                object.Equals(this.Status, another.Status) &&
                object.Equals(this.Transactions, another.Transactions) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (AdminMessage != default(string)) {
                    hash = hash * 23 + AdminMessage.GetHashCode();
                }
                if (Amount != default(long)) {
                    hash = hash * 23 + Amount.GetHashCode();
                }
                if (Charge != default(string)) {
                    hash = hash * 23 + Charge.GetHashCode();
                }
                if (ClosedAt != default(DateTime)) {
                    hash = hash * 23 + ClosedAt.GetHashCode();
                }
                if (Currency != default(string)) {
                    hash = hash * 23 + Currency.GetHashCode();
                }
                if (Documents != default(ScopedList<Document>)) {
                    hash = hash * 23 + Documents.GetHashCode();
                }
                if (FundingAmount != default(long)) {
                    hash = hash * 23 + FundingAmount.GetHashCode();
                }
                if (FundingCurrency != default(string)) {
                    hash = hash * 23 + FundingCurrency.GetHashCode();
                }
                if (Message != default(string)) {
                    hash = hash * 23 + Message.GetHashCode();
                }
                if (Metadata != default(IDictionary<string, object>)) {
                    hash = hash * 23 + Metadata.GetHashCode();
                }
                if (ReasonCode != default(DisputeReasonCode)) {
                    hash = hash * 23 + ReasonCode.GetHashCode();
                }
                if (ReasonMessage != default(string)) {
                    hash = hash * 23 + ReasonMessage.GetHashCode();
                }
                if (Status != default(DisputeStatus)) {
                    hash = hash * 23 + Status.GetHashCode();
                }
                if (Transactions != default(List<Transaction>)) {
                    hash = hash * 23 + Transactions.GetHashCode();
                }

                return hash;
            }
        }
    }
}