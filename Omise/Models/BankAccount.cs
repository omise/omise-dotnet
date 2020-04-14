using Newtonsoft.Json;

namespace Omise.Models
{
    /// <summary>
    /// Bank Account object
    ///
    /// <a href="https://www.omise.co/bank-account-api">Bank Account API</a>
    /// </summary>
    public partial class BankAccount : ModelBase
    {
        [JsonProperty("bank_code")]
        public string BankCode { get; set; }
        [JsonProperty("branch_code")]
        public string BranchCode { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("last_digits")]
        public string LastDigits { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public BankAccountType Type { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as BankAccount;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.BankCode, another.BankCode) &&
                object.Equals(this.BranchCode, another.BranchCode) &&
                object.Equals(this.Brand, another.Brand) &&
                object.Equals(this.LastDigits, another.LastDigits) &&
                object.Equals(this.Name, another.Name) &&
                object.Equals(this.Type, another.Type) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (BankCode != default(string)) {
                    hash = hash * 23 + BankCode.GetHashCode();
                }
                if (BranchCode != default(string)) {
                    hash = hash * 23 + BranchCode.GetHashCode();
                }
                if (Brand != default(string)) {
                    hash = hash * 23 + Brand.GetHashCode();
                }
                if (LastDigits != default(string)) {
                    hash = hash * 23 + LastDigits.GetHashCode();
                }
                if (Name != default(string)) {
                    hash = hash * 23 + Name.GetHashCode();
                }
                if (Type != default(BankAccountType)) {
                    hash = hash * 23 + Type.GetHashCode();
                }

                return hash;
            }
        }
    }
}