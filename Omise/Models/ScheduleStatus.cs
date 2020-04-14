using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum ScheduleStatus
    {
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "deleted")]
        Deleted,
        [EnumMember(Value = "expired")]
        Expired,
        [EnumMember(Value = "expiring")]
        Expiring,
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "suspended")]
        Suspended
    }
}
