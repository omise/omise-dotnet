using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Omise {
    // Using [EnumMember] attribute can sometime cause bad IL to be generated, so we
    // resort to our custom enum converter here.
    public class SnakeCaseEnumConverter : JsonConverter {
        class SnakeCaseNamingHack : SnakeCaseNamingStrategy {
            public string ResolvePropertyName_(string name) {
                return base.ResolvePropertyName(name);
            }
        }

        SnakeCaseNamingHack snakeCaseNames = new SnakeCaseNamingHack();

        public override bool CanConvert(Type objectType) {
            return objectType.IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if (reader.TokenType == JsonToken.Null) {
                return null;
            }

            return FromSerializedString(objectType, (string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (value == null) {
                writer.WriteNull();
            }

            writer.WriteValue(ToSerializedString(value));
        }

        public object FromSerializedString(Type targetType, string value) {
            return Enum.Parse(targetType, value.Replace("_", ""), true);
        }

        public string ToSerializedString(object value) {
            var name = Enum.GetName(value.GetType(), value);
            return snakeCaseNames.ResolvePropertyName_(name);
        }
    }
}

