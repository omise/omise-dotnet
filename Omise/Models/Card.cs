using Newtonsoft.Json;

namespace Omise.Models
{
    /// <summary>
    /// Card object
    ///
    /// <a href="https://www.omise.co/cards-api">Card API</a>
    /// </summary>
    public partial class Card : ModelBase
    {
        [JsonProperty("bank")]
        public string Bank { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("expiration_month")]
        public long ExpirationMonth { get; set; }
        [JsonProperty("expiration_year")]
        public long ExpirationYear { get; set; }
        [JsonProperty("financing")]
        public string Financing { get; set; }
        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; }
        [JsonProperty("first_digits")]
        public string FirstDigits { get; set; }
        [JsonProperty("last_digits")]
        public string LastDigits { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("security_code_check")]
        public bool SecurityCodeCheck { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("street1")]
        public string Street1 { get; set; }
        [JsonProperty("street2")]
        public string Street2 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Card;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Bank, another.Bank) &&
                object.Equals(this.Brand, another.Brand) &&
                object.Equals(this.City, another.City) &&
                object.Equals(this.Country, another.Country) &&
                object.Equals(this.ExpirationMonth, another.ExpirationMonth) &&
                object.Equals(this.ExpirationYear, another.ExpirationYear) &&
                object.Equals(this.Financing, another.Financing) &&
                object.Equals(this.Fingerprint, another.Fingerprint) &&
                object.Equals(this.FirstDigits, another.FirstDigits) &&
                object.Equals(this.LastDigits, another.LastDigits) &&
                object.Equals(this.Name, another.Name) &&
                object.Equals(this.PhoneNumber, another.PhoneNumber) &&
                object.Equals(this.PostalCode, another.PostalCode) &&
                object.Equals(this.SecurityCodeCheck, another.SecurityCodeCheck) &&
                object.Equals(this.State, another.State) &&
                object.Equals(this.Street1, another.Street1) &&
                object.Equals(this.Street2, another.Street2) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Bank != default(string)) {
                    hash = hash * 23 + Bank.GetHashCode();
                }
                if (Brand != default(string)) {
                    hash = hash * 23 + Brand.GetHashCode();
                }
                if (City != default(string)) {
                    hash = hash * 23 + City.GetHashCode();
                }
                if (Country != default(string)) {
                    hash = hash * 23 + Country.GetHashCode();
                }
                if (ExpirationMonth != default(long)) {
                    hash = hash * 23 + ExpirationMonth.GetHashCode();
                }
                if (ExpirationYear != default(long)) {
                    hash = hash * 23 + ExpirationYear.GetHashCode();
                }
                if (Financing != default(string)) {
                    hash = hash * 23 + Financing.GetHashCode();
                }
                if (Fingerprint != default(string)) {
                    hash = hash * 23 + Fingerprint.GetHashCode();
                }
                if (FirstDigits != default(string)) {
                    hash = hash * 23 + FirstDigits.GetHashCode();
                }
                if (LastDigits != default(string)) {
                    hash = hash * 23 + LastDigits.GetHashCode();
                }
                if (Name != default(string)) {
                    hash = hash * 23 + Name.GetHashCode();
                }
                if (PhoneNumber != default(string)) {
                    hash = hash * 23 + PhoneNumber.GetHashCode();
                }
                if (PostalCode != default(string)) {
                    hash = hash * 23 + PostalCode.GetHashCode();
                }
                if (SecurityCodeCheck != default(bool)) {
                    hash = hash * 23 + SecurityCodeCheck.GetHashCode();
                }
                if (State != default(string)) {
                    hash = hash * 23 + State.GetHashCode();
                }
                if (Street1 != default(string)) {
                    hash = hash * 23 + Street1.GetHashCode();
                }
                if (Street2 != default(string)) {
                    hash = hash * 23 + Street2.GetHashCode();
                }

                return hash;
            }
        }
    }

    public class CardParams : Request
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("expiration_month")]
        public long ExpirationMonth { get; set; }
        [JsonProperty("expiration_year")]
        public long ExpirationYear { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("security_code")]
        public string SecurityCode { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("street1")]
        public string Street1 { get; set; }
        [JsonProperty("street2")]
        public string Street2 { get; set; }
    }

    public class UpdateCardParams : Request
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("expiration_month")]
        public long? ExpirationMonth { get; set; }
        [JsonProperty("expiration_year")]
        public long? ExpirationYear { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
    }
}