using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum DisputeStatus
    {
        [EnumMember(Value = "closed")]
        Closed,
        [EnumMember(Value = "lost")]
        Lost,
        [EnumMember(Value = "open")]
        Open,
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "won")]
        Won
    }
}
