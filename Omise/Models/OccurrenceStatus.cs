using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum OccurrenceStatus
    {
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "scheduled")]
        Scheduled,
        [EnumMember(Value = "skipped")]
        Skipped,
        [EnumMember(Value = "successful")]
        Successful
    }
}
