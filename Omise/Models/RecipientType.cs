using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum RecipientType
    {
        [EnumMember(Value = "corporation")]
        Corporation,
        [EnumMember(Value = "individual")]
        Individual
    }
}
