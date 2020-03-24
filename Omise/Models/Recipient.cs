using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Omise.Models
{
    /// <summary>
    /// Recipient object
    ///
    /// <a href="https://www.omise.co/recipients-api">Recipient API</a>
    /// </summary>
    public partial class Recipient : ModelBase
    {
        [JsonProperty("activated_at")]
        public DateTime ActivatedAt { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("bank_account")]
        public BankAccount BankAccount { get; set; }
        [JsonProperty("default")]
        public bool Default { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("failure_code")]
        public RecipientFailureCode FailureCode { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("schedule")]
        public string Schedule { get; set; }
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
        [JsonProperty("type")]
        public RecipientType Type { get; set; }
        [JsonProperty("verified")]
        public bool Verified { get; set; }
        [JsonProperty("verified_at")]
        public DateTime VerifiedAt { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Recipient;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.ActivatedAt, another.ActivatedAt) &&
                object.Equals(this.Active, another.Active) &&
                object.Equals(this.BankAccount, another.BankAccount) &&
                object.Equals(this.Default, another.Default) &&
                object.Equals(this.Description, another.Description) &&
                object.Equals(this.Email, another.Email) &&
                object.Equals(this.FailureCode, another.FailureCode) &&
                object.Equals(this.Metadata, another.Metadata) &&
                object.Equals(this.Name, another.Name) &&
                object.Equals(this.Schedule, another.Schedule) &&
                object.Equals(this.TaxId, another.TaxId) &&
                object.Equals(this.Type, another.Type) &&
                object.Equals(this.Verified, another.Verified) &&
                object.Equals(this.VerifiedAt, another.VerifiedAt) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (ActivatedAt != default(DateTime)) {
                    hash = hash * 23 + ActivatedAt.GetHashCode();
                }
                if (Active != default(bool)) {
                    hash = hash * 23 + Active.GetHashCode();
                }
                if (BankAccount != default(BankAccount)) {
                    hash = hash * 23 + BankAccount.GetHashCode();
                }
                if (Default != default(bool)) {
                    hash = hash * 23 + Default.GetHashCode();
                }
                if (Description != default(string)) {
                    hash = hash * 23 + Description.GetHashCode();
                }
                if (Email != default(string)) {
                    hash = hash * 23 + Email.GetHashCode();
                }
                if (FailureCode != default(RecipientFailureCode)) {
                    hash = hash * 23 + FailureCode.GetHashCode();
                }
                if (Metadata != default(IDictionary<string, object>)) {
                    hash = hash * 23 + Metadata.GetHashCode();
                }
                if (Name != default(string)) {
                    hash = hash * 23 + Name.GetHashCode();
                }
                if (Schedule != default(string)) {
                    hash = hash * 23 + Schedule.GetHashCode();
                }
                if (TaxId != default(string)) {
                    hash = hash * 23 + TaxId.GetHashCode();
                }
                if (Type != default(RecipientType)) {
                    hash = hash * 23 + Type.GetHashCode();
                }
                if (Verified != default(bool)) {
                    hash = hash * 23 + Verified.GetHashCode();
                }
                if (VerifiedAt != default(DateTime)) {
                    hash = hash * 23 + VerifiedAt.GetHashCode();
                }

                return hash;
            }
        }
    }

    public class CreateRecipientParams : Request
    {
        [JsonProperty("bank_account")]
        public BankAccountParams BankAccount { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
        [JsonProperty("type")]
        public RecipientType Type { get; set; }
    }

    public class UpdateRecipientParams : Request
    {
        [JsonProperty("bank_account")]
        public BankAccountParams BankAccount { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
        [JsonProperty("type")]
        public RecipientType Type { get; set; }
    }
}