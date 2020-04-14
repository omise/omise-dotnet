using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum SourceOfFund
    {
        [EnumMember(Value = "card")]
        Card,
        [EnumMember(Value = "offline")]
        Offline,
        [EnumMember(Value = "offsite")]
        Offsite
    }
}
