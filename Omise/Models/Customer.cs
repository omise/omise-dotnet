using Newtonsoft.Json;
using System.Collections.Generic;

namespace Omise.Models
{
    /// <summary>
    /// Customer object
    ///
    /// <a href="https://www.omise.co/customers-api">Customer API</a>
    /// </summary>
    public partial class Customer : ModelBase
    {
        [JsonProperty("cards")]
        public ScopedList<Card> Cards { get; set; }
        [JsonProperty("default_card")]
        public string DefaultCard { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Customer;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Cards, another.Cards) &&
                object.Equals(this.DefaultCard, another.DefaultCard) &&
                object.Equals(this.Description, another.Description) &&
                object.Equals(this.Email, another.Email) &&
                object.Equals(this.Metadata, another.Metadata) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Cards != default(ScopedList<Card>)) {
                    hash = hash * 23 + Cards.GetHashCode();
                }
                if (DefaultCard != default(string)) {
                    hash = hash * 23 + DefaultCard.GetHashCode();
                }
                if (Description != default(string)) {
                    hash = hash * 23 + Description.GetHashCode();
                }
                if (Email != default(string)) {
                    hash = hash * 23 + Email.GetHashCode();
                }
                if (Metadata != default(IDictionary<string, object>)) {
                    hash = hash * 23 + Metadata.GetHashCode();
                }

                return hash;
            }
        }
    }

    public class CreateCustomerParams : Request
    {
        [JsonProperty("card")]
        public string Card { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
    }

    public class UpdateCustomerCardParams : Request
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

    public class UpdateCustomerParams : Request
    {
        [JsonProperty("card")]
        public string Card { get; set; }
        [JsonProperty("default_card")]
        public string DefaultCard { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
    }
}