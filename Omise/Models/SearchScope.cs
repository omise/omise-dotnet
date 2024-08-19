using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum SearchScope
    {
        [EnumMember(Value = null)]
        Unspecified,
        [EnumMember(Value = "dispute")]
        Dispute,
        [EnumMember(Value = "charge")]
        Charge,
        [EnumMember(Value = "charge_schedule")]
        ChargeSchedule,
        [EnumMember(Value = "customer")]
        Customer,
        [EnumMember(Value = "recipient")]
        Recipient,
        [EnumMember(Value = "receipt")]
        Receipt,
        [EnumMember(Value = "refund")]
        Refund,
        [EnumMember(Value = "transfer")]
        Transfer,
        [EnumMember(Value = "transfer_schedule")]
        TransferSchedule,
        [EnumMember(Value = "link")]
        Link,
        [EnumMember(Value = "transaction")]
        Transaction,
    }
}

