using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum AuthTypes
    {
        [EnumMember(Value = "pre_auth")]
         PreAuth,
        [EnumMember(Value = "final_auth")]
        FinalAuth
    }
}
