using System.Runtime.Serialization;

namespace Omise.Models {
    public enum RecipientType {
        [EnumMember(Value = "individual")]
        Individual,
        [EnumMember(Value = "corporation")]
        Corporation
    }
}