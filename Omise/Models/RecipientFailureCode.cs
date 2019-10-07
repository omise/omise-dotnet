using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum RecipientFailureCode
    {
        [EnumMember(Value = "account_not_found")]
        AccountNotFound,
        [EnumMember(Value = "bank_not_found")]
        BankNotFound,
        [EnumMember(Value = "name_mismatch")]
        NameMismatch
    }
}
