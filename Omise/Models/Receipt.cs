using Newtonsoft.Json;
using System;

namespace Omise.Models
{
    /// <summary>
    /// Receipt object
    ///
    /// <a href="https://www.omise.co/receipts-api">Receipt API</a>
    /// </summary>
    public partial class Receipt : ModelBase
    {
        [JsonProperty("adjustment_transaction")]
        public Transaction AdjustmentTransaction { get; set; }
        [JsonProperty("charge_fee")]
        public long ChargeFee { get; set; }
        [JsonProperty("company_address")]
        public string CompanyAddress { get; set; }
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }
        [JsonProperty("company_tax_id")]
        public string CompanyTaxId { get; set; }
        [JsonProperty("credit_note")]
        public bool CreditNote { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("customer_address")]
        public string CustomerAddress { get; set; }
        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; }
        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }
        [JsonProperty("customer_statement_name")]
        public string CustomerStatementName { get; set; }
        [JsonProperty("customer_tax_id")]
        public string CustomerTaxId { get; set; }
        [JsonProperty("issued_on")]
        public DateTime IssuedOn { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("subtotal")]
        public long Subtotal { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("transfer_fee")]
        public long TransferFee { get; set; }
        [JsonProperty("vat")]
        public long Vat { get; set; }
        [JsonProperty("voided_fee")]
        public long VoidedFee { get; set; }
        [JsonProperty("wht")]
        public long Wht { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Receipt;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.AdjustmentTransaction, another.AdjustmentTransaction) &&
                object.Equals(this.ChargeFee, another.ChargeFee) &&
                object.Equals(this.CompanyAddress, another.CompanyAddress) &&
                object.Equals(this.CompanyName, another.CompanyName) &&
                object.Equals(this.CompanyTaxId, another.CompanyTaxId) &&
                object.Equals(this.CreditNote, another.CreditNote) &&
                object.Equals(this.Currency, another.Currency) &&
                object.Equals(this.CustomerAddress, another.CustomerAddress) &&
                object.Equals(this.CustomerEmail, another.CustomerEmail) &&
                object.Equals(this.CustomerName, another.CustomerName) &&
                object.Equals(this.CustomerStatementName, another.CustomerStatementName) &&
                object.Equals(this.CustomerTaxId, another.CustomerTaxId) &&
                object.Equals(this.IssuedOn, another.IssuedOn) &&
                object.Equals(this.Number, another.Number) &&
                object.Equals(this.Subtotal, another.Subtotal) &&
                object.Equals(this.Total, another.Total) &&
                object.Equals(this.TransferFee, another.TransferFee) &&
                object.Equals(this.Vat, another.Vat) &&
                object.Equals(this.VoidedFee, another.VoidedFee) &&
                object.Equals(this.Wht, another.Wht) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (AdjustmentTransaction != default(Transaction)) {
                    hash = hash * 23 + AdjustmentTransaction.GetHashCode();
                }
                if (ChargeFee != default(long)) {
                    hash = hash * 23 + ChargeFee.GetHashCode();
                }
                if (CompanyAddress != default(string)) {
                    hash = hash * 23 + CompanyAddress.GetHashCode();
                }
                if (CompanyName != default(string)) {
                    hash = hash * 23 + CompanyName.GetHashCode();
                }
                if (CompanyTaxId != default(string)) {
                    hash = hash * 23 + CompanyTaxId.GetHashCode();
                }
                if (CreditNote != default(bool)) {
                    hash = hash * 23 + CreditNote.GetHashCode();
                }
                if (Currency != default(string)) {
                    hash = hash * 23 + Currency.GetHashCode();
                }
                if (CustomerAddress != default(string)) {
                    hash = hash * 23 + CustomerAddress.GetHashCode();
                }
                if (CustomerEmail != default(string)) {
                    hash = hash * 23 + CustomerEmail.GetHashCode();
                }
                if (CustomerName != default(string)) {
                    hash = hash * 23 + CustomerName.GetHashCode();
                }
                if (CustomerStatementName != default(string)) {
                    hash = hash * 23 + CustomerStatementName.GetHashCode();
                }
                if (CustomerTaxId != default(string)) {
                    hash = hash * 23 + CustomerTaxId.GetHashCode();
                }
                if (IssuedOn != default(DateTime)) {
                    hash = hash * 23 + IssuedOn.GetHashCode();
                }
                if (Number != default(string)) {
                    hash = hash * 23 + Number.GetHashCode();
                }
                if (Subtotal != default(long)) {
                    hash = hash * 23 + Subtotal.GetHashCode();
                }
                if (Total != default(long)) {
                    hash = hash * 23 + Total.GetHashCode();
                }
                if (TransferFee != default(long)) {
                    hash = hash * 23 + TransferFee.GetHashCode();
                }
                if (Vat != default(long)) {
                    hash = hash * 23 + Vat.GetHashCode();
                }
                if (VoidedFee != default(long)) {
                    hash = hash * 23 + VoidedFee.GetHashCode();
                }
                if (Wht != default(long)) {
                    hash = hash * 23 + Wht.GetHashCode();
                }

                return hash;
            }
        }
    }
}