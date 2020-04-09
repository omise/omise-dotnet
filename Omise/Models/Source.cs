using Newtonsoft.Json;

namespace Omise.Models
{
    /// <summary>
    /// Source object
    ///
    /// <a href="https://www.omise.co/sources-api">Source API</a>
    /// </summary>
    public partial class Source : ModelBase
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("barcode")]
        public string Barcode { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("flow")]
        public FlowTypes Flow { get; set; }
        [JsonProperty("installment_term")]
        public long InstallmentTerm { get; set; }
        [JsonProperty("mobile_number")]
        public string MobileNumber { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("references")]
        public PaymentReference References { get; set; }
        [JsonProperty("scannable_code")]
        public Barcode ScannableCode { get; set; }
        [JsonProperty("store_id")]
        public string StoreId { get; set; }
        [JsonProperty("store_name")]
        public string StoreName { get; set; }
        [JsonProperty("terminal_id")]
        public string TerminalId { get; set; }
        [JsonProperty("type")]
        public SourceType Type { get; set; }
        [JsonProperty("zero_interest_installments")]
        public bool ZeroInterestInstallments { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Source;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Amount, another.Amount) &&
                object.Equals(this.Barcode, another.Barcode) &&
                object.Equals(this.Currency, another.Currency) &&
                object.Equals(this.Email, another.Email) &&
                object.Equals(this.Flow, another.Flow) &&
                object.Equals(this.InstallmentTerm, another.InstallmentTerm) &&
                object.Equals(this.MobileNumber, another.MobileNumber) &&
                object.Equals(this.Name, another.Name) &&
                object.Equals(this.PhoneNumber, another.PhoneNumber) &&
                object.Equals(this.References, another.References) &&
                object.Equals(this.ScannableCode, another.ScannableCode) &&
                object.Equals(this.StoreId, another.StoreId) &&
                object.Equals(this.StoreName, another.StoreName) &&
                object.Equals(this.TerminalId, another.TerminalId) &&
                object.Equals(this.Type, another.Type) &&
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
                if (Barcode != default(string)) {
                    hash = hash * 23 + Barcode.GetHashCode();
                }
                if (Currency != default(string)) {
                    hash = hash * 23 + Currency.GetHashCode();
                }
                if (Email != default(string)) {
                    hash = hash * 23 + Email.GetHashCode();
                }
                if (Flow != default(FlowTypes)) {
                    hash = hash * 23 + Flow.GetHashCode();
                }
                if (InstallmentTerm != default(long)) {
                    hash = hash * 23 + InstallmentTerm.GetHashCode();
                }
                if (MobileNumber != default(string)) {
                    hash = hash * 23 + MobileNumber.GetHashCode();
                }
                if (Name != default(string)) {
                    hash = hash * 23 + Name.GetHashCode();
                }
                if (PhoneNumber != default(string)) {
                    hash = hash * 23 + PhoneNumber.GetHashCode();
                }
                if (References != default(PaymentReference)) {
                    hash = hash * 23 + References.GetHashCode();
                }
                if (ScannableCode != default(Barcode)) {
                    hash = hash * 23 + ScannableCode.GetHashCode();
                }
                if (StoreId != default(string)) {
                    hash = hash * 23 + StoreId.GetHashCode();
                }
                if (StoreName != default(string)) {
                    hash = hash * 23 + StoreName.GetHashCode();
                }
                if (TerminalId != default(string)) {
                    hash = hash * 23 + TerminalId.GetHashCode();
                }
                if (Type != default(SourceType)) {
                    hash = hash * 23 + Type.GetHashCode();
                }
                if (ZeroInterestInstallments != default(bool)) {
                    hash = hash * 23 + ZeroInterestInstallments.GetHashCode();
                }

                return hash;
            }
        }
    }
}