using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum ChargeStatus
    {
        [EnumMember(Value = "expired")]
        Expired,
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "reversed")]
        Reversed,
        [EnumMember(Value = "successful")]
        Successful
    }
}
