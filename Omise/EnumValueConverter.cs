using System;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using CacheDict = System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.IDictionary<string, string>>;
using FieldMappings = System.Collections.Generic.Dictionary<string, string>;
using ICacheDict = System.Collections.Generic.IDictionary<System.Type, System.Collections.Generic.IDictionary<string, string>>;
using IFieldMappings = System.Collections.Generic.IDictionary<string, string>;
using System.Reflection;

namespace Omise
{
    // Using [EnumMember] attribute with StringEnumConverter can sometimes cause bad IL
    // to be generated, so we resort to our custom enum converter here.
    public sealed class EnumValueConverter : JsonConverter
    {
        class SnakeCaseNamingHack : SnakeCaseNamingStrategy
        {
            public string ResolvePropertyName_(string name)
            {
                return base.ResolvePropertyName(name);
            }
        }

        readonly ICacheDict valueCache = new CacheDict();
        readonly ICacheDict nameCache = new CacheDict();
        readonly SnakeCaseNamingHack namer = new SnakeCaseNamingHack();

        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            return FromSerializedString(objectType, (string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }

            writer.WriteValue(ToSerializedString(value.GetType(), value));
        }

        public object FromSerializedString(Type type, string serialized)
        {
            var mappings = valueMappingsFor(type);
            if (!mappings.ContainsKey(serialized)) return null;

            return Enum.Parse(type, mappings[serialized], true);
        }

        public string ToSerializedString(Type type, object enumValue)
        {
            var name = Enum.GetName(type, enumValue);
            var mappings = nameMappingsFor(type);
            if (!mappings.ContainsKey(name)) return null;

            return mappings[name];
        }

        IFieldMappings nameMappingsFor(Type type)
        {
            // assume type.IsEnum == true
            if (nameCache.ContainsKey(type))
            {
                return nameCache[type];
            }

            var mappings = new FieldMappings();
            var typeInfo = type.GetTypeInfo();

            var fields = type.GetRuntimeFields();
            foreach (var field in fields)
            {
                var name = field.Name;
                var value = namer.ResolvePropertyName_(name);

                var enumMemberAttr = field
                    .GetCustomAttributes(false)
                    .OfType<EnumMemberAttribute>()
                    .LastOrDefault();
                if (enumMemberAttr != null)
                {
                    value = enumMemberAttr.Value;
                }

                if (value != null)
                {
                    mappings[name] = value;
                }
            }

            return nameCache[type] = mappings;
        }

        IFieldMappings valueMappingsFor(Type type)
        {
            if (valueCache.ContainsKey(type))
            {
                return valueCache[type];
            }

            var nameMappings = nameMappingsFor(type);
            var mappings = new FieldMappings();
            foreach (var entry in nameMappings)
            {
                mappings[entry.Value] = entry.Key;
            }

            return valueCache[type] = mappings;
        }
    }
}
