using System;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Omise.Models {
    public enum Ordering {
        [EnumMember(Value = "chronological")]
        Chronological,
        [EnumMember(Value = "reverse_chronological")]
        ReverseChronological
    }
}

