using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum FlowTypes
    {
        [EnumMember(Value = null)]
        None,
        [EnumMember(Value = "offline")]
        Offline,
        [EnumMember(Value = "redirect")]
        Redirect
    }
}
