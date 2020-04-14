using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum TransactionDirection
    {
        [EnumMember(Value = "credit")]
        Credit,
        [EnumMember(Value = "debit")]
        Debit
    }
}
