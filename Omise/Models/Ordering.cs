using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum Ordering
    {
        [EnumMember(Value = null)]
        Unspecified,
        [EnumMember(Value = "chronological")]
        Chronological,
        [EnumMember(Value = "reverse_chronological")]
        ReverseChronological
    }
}