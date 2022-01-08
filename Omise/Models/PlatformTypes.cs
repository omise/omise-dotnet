using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum PlatformTypes
    {
        [EnumMember(Value = null)]
        None,
        [EnumMember(Value = "WEB")]
        Web,
        [EnumMember(Value = "iOS")]
        iOS,
        [EnumMember(Value = "ANDROID")]
        Android,
    }
}
