using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Omise.Models
{
    /// <summary>
    /// Charge object
    ///
    /// <a href="https://www.omise.co/charges-api">Charge API</a>
    /// </summary>
    public partial class Charge : ModelBase
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("authorize_uri")]
        public string AuthorizeURI { get; set; }
        [JsonProperty("authorized")]
        public bool Authorized { get; set; }
        [JsonProperty("capturable")]
        public bool Capturable { get; set; }
        [JsonProperty("capture")]
        public bool Capture { get; set; }
        [JsonProperty("card")]
        public Card Card { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("customer")]
        public string Customer { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("disputable")]
        public bool Disputable { get; set; }
        [JsonProperty("dispute")]
        public Dispute Dispute { get; set; }
        [JsonProperty("expired")]
        public bool Expired { get; set; }
        [JsonProperty("expired_at")]
        public DateTime ExpiredAt { get; set; }
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }
        [JsonProperty("failure_code")]
        public ChargeFailureCode FailureCode { get; set; }
        [JsonProperty("failure_message")]
        public string FailureMessage { get; set; }
        [JsonProperty("fee")]
        public long Fee { get; set; }
        [JsonProperty("fee_vat")]
        public long FeeVat { get; set; }
        [JsonProperty("funding_amount")]
        public long FundingAmount { get; set; }
        [JsonProperty("funding_currency")]
        public string FundingCurrency { get; set; }
        [JsonProperty("interest")]
        public long Interest { get; set; }
        [JsonProperty("interest_vat")]
        public long InterestVat { get; set; }
        [JsonProperty("ip")]
        public string Ip { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
        [JsonProperty("net")]
        public long Net { get; set; }
        [JsonProperty("paid")]
        public bool Paid { get; set; }
        [JsonProperty("paid_at")]
        public DateTime PaidAt { get; set; }
        [JsonProperty("platform_fee")]
        public PlatformFee PlatformFee { get; set; }
        [JsonProperty("refundable")]
        public bool Refundable { get; set; }
        [JsonProperty("refunded_amount")]
        public long RefundedAmount { get; set; }
        [JsonProperty("refunds")]
        public ScopedList<Refund> Refunds { get; set; }
        [JsonProperty("return_uri")]
        public string ReturnUri { get; set; }
        [JsonProperty("reversed")]
        public bool Reversed { get; set; }
        [JsonProperty("reversed_at")]
        public DateTime ReversedAt { get; set; }
        [JsonProperty("reversible")]
        public bool Reversible { get; set; }
        [JsonProperty("schedule")]
        public string Schedule { get; set; }
        [JsonProperty("source")]
        public Source Source { get; set; }
        [JsonProperty("status")]
        public ChargeStatus Status { get; set; }
        [JsonProperty("transaction")]
        public string Transaction { get; set; }
        [JsonProperty("voided")]
        public bool Voided { get; set; }
        [JsonProperty("zero_interest_installments")]
        public bool ZeroInterestInstallments { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Charge;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Amount, another.Amount) &&
                object.Equals(this.AuthorizeURI, another.AuthorizeURI) &&
                object.Equals(this.Authorized, another.Authorized) &&
                object.Equals(this.Capturable, another.Capturable) &&
                object.Equals(this.Capture, another.Capture) &&
                object.Equals(this.Card, another.Card) &&
                object.Equals(this.Currency, another.Currency) &&
                object.Equals(this.Customer, another.Customer) &&
                object.Equals(this.Description, another.Description) &&
                object.Equals(this.Disputable, another.Disputable) &&
                object.Equals(this.Dispute, another.Dispute) &&
                object.Equals(this.Expired, another.Expired) &&
                object.Equals(this.ExpiredAt, another.ExpiredAt) &&
                object.Equals(this.ExpiresAt, another.ExpiresAt) &&
                object.Equals(this.FailureCode, another.FailureCode) &&
                object.Equals(this.FailureMessage, another.FailureMessage) &&
                object.Equals(this.Fee, another.Fee) &&
                object.Equals(this.FeeVat, another.FeeVat) &&
                object.Equals(this.FundingAmount, another.FundingAmount) &&
                object.Equals(this.FundingCurrency, another.FundingCurrency) &&
                object.Equals(this.Interest, another.Interest) &&
                object.Equals(this.InterestVat, another.InterestVat) &&
                object.Equals(this.Ip, another.Ip) &&
                object.Equals(this.Link, another.Link) &&
                object.Equals(this.Metadata, another.Metadata) &&
                object.Equals(this.Net, another.Net) &&
                object.Equals(this.Paid, another.Paid) &&
                object.Equals(this.PaidAt, another.PaidAt) &&
                object.Equals(this.PlatformFee, another.PlatformFee) &&
                object.Equals(this.Refundable, another.Refundable) &&
                object.Equals(this.RefundedAmount, another.RefundedAmount) &&
                object.Equals(this.Refunds, another.Refunds) &&
                object.Equals(this.ReturnUri, another.ReturnUri) &&
                object.Equals(this.Reversed, another.Reversed) &&
                object.Equals(this.ReversedAt, another.ReversedAt) &&
                object.Equals(this.Reversible, another.Reversible) &&
                object.Equals(this.Schedule, another.Schedule) &&
                object.Equals(this.Source, another.Source) &&
                object.Equals(this.Status, another.Status) &&
                object.Equals(this.Transaction, another.Transaction) &&
                object.Equals(this.Voided, another.Voided) &&
                object.Equals(this.ZeroInterestInstallments, another.ZeroInterestInstallments) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Amount != default(long)) {
                    hash = hash * 23 + Amount.GetHashCode();
                }
                if (AuthorizeURI != default(string)) {
                    hash = hash * 23 + AuthorizeURI.GetHashCode();
                }
                if (Authorized != default(bool)) {
                    hash = hash * 23 + Authorized.GetHashCode();
                }
                if (Capturable != default(bool)) {
                    hash = hash * 23 + Capturable.GetHashCode();
                }
                if (Capture != default(bool)) {
                    hash = hash * 23 + Capture.GetHashCode();
                }
                if (Card != default(Card)) {
                    hash = hash * 23 + Card.GetHashCode();
                }
                if (Currency != default(string)) {
                    hash = hash * 23 + Currency.GetHashCode();
                }
                if (Customer != default(string)) {
                    hash = hash * 23 + Customer.GetHashCode();
                }
                if (Description != default(string)) {
                    hash = hash * 23 + Description.GetHashCode();
                }
                if (Disputable != default(bool)) {
                    hash = hash * 23 + Disputable.GetHashCode();
                }
                if (Dispute != default(Dispute)) {
                    hash = hash * 23 + Dispute.GetHashCode();
                }
                if (Expired != default(bool)) {
                    hash = hash * 23 + Expired.GetHashCode();
                }
                if (ExpiredAt != default(DateTime)) {
                    hash = hash * 23 + ExpiredAt.GetHashCode();
                }
                if (ExpiresAt != default(DateTime)) {
                    hash = hash * 23 + ExpiresAt.GetHashCode();
                }
                if (FailureCode != default(ChargeFailureCode)) {
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
                if (FundingAmount != default(long)) {
                    hash = hash * 23 + FundingAmount.GetHashCode();
                }
                if (FundingCurrency != default(string)) {
                    hash = hash * 23 + FundingCurrency.GetHashCode();
                }
                if (Interest != default(long)) {
                    hash = hash * 23 + Interest.GetHashCode();
                }
                if (InterestVat != default(long)) {
                    hash = hash * 23 + InterestVat.GetHashCode();
                }
                if (Ip != default(string)) {
                    hash = hash * 23 + Ip.GetHashCode();
                }
                if (Link != default(string)) {
                    hash = hash * 23 + Link.GetHashCode();
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
                if (PlatformFee != default(PlatformFee)) {
                    hash = hash * 23 + PlatformFee.GetHashCode();
                }
                if (Refundable != default(bool)) {
                    hash = hash * 23 + Refundable.GetHashCode();
                }
                if (RefundedAmount != default(long)) {
                    hash = hash * 23 + RefundedAmount.GetHashCode();
                }
                if (Refunds != default(ScopedList<Refund>)) {
                    hash = hash * 23 + Refunds.GetHashCode();
                }
                if (ReturnUri != default(string)) {
                    hash = hash * 23 + ReturnUri.GetHashCode();
                }
                if (Reversed != default(bool)) {
                    hash = hash * 23 + Reversed.GetHashCode();
                }
                if (ReversedAt != default(DateTime)) {
                    hash = hash * 23 + ReversedAt.GetHashCode();
                }
                if (Reversible != default(bool)) {
                    hash = hash * 23 + Reversible.GetHashCode();
                }
                if (Schedule != default(string)) {
                    hash = hash * 23 + Schedule.GetHashCode();
                }
                if (Source != default(Source)) {
                    hash = hash * 23 + Source.GetHashCode();
                }
                if (Status != default(ChargeStatus)) {
                    hash = hash * 23 + Status.GetHashCode();
                }
                if (Transaction != default(string)) {
                    hash = hash * 23 + Transaction.GetHashCode();
                }
                if (Voided != default(bool)) {
                    hash = hash * 23 + Voided.GetHashCode();
                }
                if (ZeroInterestInstallments != default(bool)) {
                    hash = hash * 23 + ZeroInterestInstallments.GetHashCode();
                }

                return hash;
            }
        }
    }
}