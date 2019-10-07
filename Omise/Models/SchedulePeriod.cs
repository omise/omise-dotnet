using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum SchedulePeriod
    {
        [EnumMember(Value = "day")]
        Day,
        [EnumMember(Value = "month")]
        Month,
        [EnumMember(Value = "week")]
        Week
    }
}
