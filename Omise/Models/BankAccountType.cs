using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum BankAccountType
    {
        [EnumMember(Value = "current")]
        Current,
        [EnumMember(Value = "normal")]
        Normal
    }
}
