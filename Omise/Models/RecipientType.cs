using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Omise.Models {
    public enum RecipientType {
        [EnumMember(Value = "individual")]
        Individual,
        [EnumMember(Value = "corporation")]
        Corporation
    }
}

