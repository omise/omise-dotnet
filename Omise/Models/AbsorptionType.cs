using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum AbsorptionType
    {
        [EnumMember(Value = "merchant")]
        Merchant,

        [EnumMember(Value = "customer")]
        Customer
    }
}