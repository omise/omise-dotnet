using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Omise.Models
{
    public partial class Transfer : ModelBase
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("bank_account")]
        public BankAccount BankAccount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("fail_fast")]
        public bool FailFast { get; set; }
        [JsonProperty("failure_code")]
        public string FailureCode { get; set; }
        [JsonProperty("failure_message")]
        public string FailureMessage { get; set; }
        [JsonProperty("fee")]
        public long Fee { get; set; }
        [JsonProperty("fee_vat")]
        public long FeeVat { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
        [JsonProperty("net")]
        public long Net { get; set; }
        [JsonProperty("paid")]
        public bool Paid { get; set; }
        [JsonProperty("paid_at")]
        public DateTime PaidAt { get; set; }
        [JsonProperty("recipient")]
        public string Recipient { get; set; }
        [JsonProperty("sendable")]
        public bool Sendable { get; set; }
        [JsonProperty("sent")]
        public bool Sent { get; set; }
        [JsonProperty("sent_at")]
        public DateTime SentAt { get; set; }
        [JsonProperty("total_fee")]
        public long TotalFee { get; set; }
        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Transfer;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Amount, another.Amount) &&
                object.Equals(this.BankAccount, another.BankAccount) &&
                object.Equals(this.Currency, another.Currency) &&
                object.Equals(this.FailFast, another.FailFast) &&
                object.Equals(this.FailureCode, another.FailureCode) &&
                object.Equals(this.FailureMessage, another.FailureMessage) &&
                object.Equals(this.Fee, another.Fee) &&
                object.Equals(this.FeeVat, another.FeeVat) &&
                object.Equals(this.Metadata, another.Metadata) &&
                object.Equals(this.Net, another.Net) &&
                object.Equals(this.Paid, another.Paid) &&
                object.Equals(this.PaidAt, another.PaidAt) &&
                object.Equals(this.Recipient, another.Recipient) &&
                object.Equals(this.Sendable, another.Sendable) &&
                object.Equals(this.Sent, another.Sent) &&
                object.Equals(this.SentAt, another.SentAt) &&
                object.Equals(this.TotalFee, another.TotalFee) &&
                object.Equals(this.Transactions, another.Transactions) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Amount != default(long)) {
                    hash = hash * 23 + Amount.GetHashCode();
                }
                if (BankAccount != default(BankAccount)) {
                    hash = hash * 23 + BankAccount.GetHashCode();
                }
                if (Currency != default(string)) {
                    hash = hash * 23 + Currency.GetHashCode();
                }
                if (FailFast != default(bool)) {
                    hash = hash * 23 + FailFast.GetHashCode();
                }
                if (FailureCode != default(string)) {
                    hash = hash * 23 + FailureCode.GetHashCode();
                }
                if (FailureMessage != default(string)) {
                    hash = hash * 23 + FailureMessage.GetHashCode();
                }
                if (Fee != default(long)) {
                    hash = hash * 23 + Fee.GetHashCode();
                }
                if (FeeVat != default(long)) {
                    hash = hash * 23 + FeeVat.GetHashCode();
                }
                if (Metadata != default(IDictionary<string, object>)) {
                    hash = hash * 23 + Metadata.GetHashCode();
                }
                if (Net != default(long)) {
                    hash = hash * 23 + Net.GetHashCode();
                }
                if (Paid != default(bool)) {
                    hash = hash * 23 + Paid.GetHashCode();
                }
                if (PaidAt != default(DateTime)) {
                    hash = hash * 23 + PaidAt.GetHashCode();
                }
                if (Recipient != default(string)) {
                    hash = hash * 23 + Recipient.GetHashCode();
                }
                if (Sendable != default(bool)) {
                    hash = hash * 23 + Sendable.GetHashCode();
                }
                if (Sent != default(bool)) {
                    hash = hash * 23 + Sent.GetHashCode();
                }
                if (SentAt != default(DateTime)) {
                    hash = hash * 23 + SentAt.GetHashCode();
                }
                if (TotalFee != default(long)) {
                    hash = hash * 23 + TotalFee.GetHashCode();
                }
                if (Transactions != default(List<Transaction>)) {
                    hash = hash * 23 + Transactions.GetHashCode();
                }

                return hash;
            }
        }
    }

    public class CreateTransferParams : Request
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("fail_fast")]
        public bool FailFast { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
        [JsonProperty("recipient")]
        public string Recipient { get; set; }
    }

    public class UpdateTransferParams : Request
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
    }
}