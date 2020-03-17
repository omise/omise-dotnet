using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum AccountType
    {
        [EnumMember(Value = "current")]
        Current,
        [EnumMember(Value = "normal")]
        Normal
    }
}
