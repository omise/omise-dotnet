using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum AuthTypes
    {
        [EnumMember(Value = null)]
         None,
        [EnumMember(Value = "pre_auth")]
         PreAuth,
        [EnumMember(Value = "final_auth")]
        FinalAuth
    }
}
