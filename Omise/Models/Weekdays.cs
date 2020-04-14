using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum Weekdays
    {
        [EnumMember(Value = "friday")]
        Friday,
        [EnumMember(Value = "monday")]
        Monday,
        [EnumMember(Value = "saturday")]
        Saturday,
        [EnumMember(Value = "sunday")]
        Sunday,
        [EnumMember(Value = "thursday")]
        Thursday,
        [EnumMember(Value = "tuesday")]
        Tuesday,
        [EnumMember(Value = "wednesday")]
        Wednesday
    }
}
