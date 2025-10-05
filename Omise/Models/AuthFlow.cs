using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum AuthFlow
    {
        [EnumMember(Value = "PASSKEY")]
        Passkey,
        [EnumMember(Value = "3DS")]
        ThreeDS
    }
}
