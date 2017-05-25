using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Omise
{
    public sealed class Serializer
    {
        readonly JsonSerializer jsonSerializer;
        readonly EnumValueConverter enumConverter;

        public Serializer()
        {
            enumConverter = new EnumValueConverter();

            // TODO: enumConverter will emit `null` for null values but in our case we are
            //   using NullValueHandling.Ignore and [EnumMember] to handle null enums which
            //   effectively fools JsonSerializer into thinking the field is not null.
            //   There is no simple way to fix unless we roll our own complicated
            //   IContractResolver implementation and whole shebangs related things.
            jsonSerializer = new JsonSerializer();
            jsonSerializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializer.Converters.Add(enumConverter);
            jsonSerializer.NullValueHandling = NullValueHandling.Ignore;
        }

        public void JsonSerialize<T>(Stream target, T payload) where T : class
        {
            using (var writer = new StreamWriter(target))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                jsonSerializer.Serialize(jsonWriter, payload);
            }
        }

        public T JsonDeserialize<T>(Stream target) where T : class
        {
            using (var reader = new StreamReader(target))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return jsonSerializer.Deserialize<T>(jsonReader);
            }
        }

        public void JsonPopulate(string json, object target)
        {
            var buffer = Encoding.UTF8.GetBytes(json);

            using (var stream = new MemoryStream(buffer))
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                jsonSerializer.Populate(jsonReader, target);
            }
        }


        public FormUrlEncodedContent ExtractFormValues(object payload)
        {
            var values = ExtractFormValues(payload, null);
            return new FormUrlEncodedContent(values);
        }

        IEnumerable<KeyValuePair<string, string>> ExtractFormValues(
            object payload,
            string prefix
        )
        {
            var clrAsm = typeof(object).GetTypeInfo().Assembly;
            var stringDict = typeof(IDictionary<string, string>).GetTypeInfo();

            var props = payload.GetType().GetRuntimeProperties();
            foreach (var prop in props)
            {
                var value = prop.GetValue(payload, null);
                if (value == null) continue;

                var name = prop.GetCustomAttributes(true)
                    .Where(obj => obj is JsonPropertyAttribute)
                    .Cast<JsonPropertyAttribute>()
                    .Select(attr => attr.PropertyName)
                    .FirstOrDefault() ??
                           prop.Name.ToLower();

                if (!string.IsNullOrEmpty(prefix))
                {
                    name = $"{prefix}[{name}]";
                }

                var typeInfo = value.GetType().GetTypeInfo();
                if (typeInfo.IsClass && typeInfo.Assembly != clrAsm)
                {
                    foreach (var result in ExtractFormValues(value, name))
                    {
                        yield return result;
                    }

                }
                else if (stringDict.IsAssignableFrom(typeInfo))
                {
                    var dict = (IDictionary<string, string>)value;
                    foreach (var entry in dict)
                    {
                        yield return new KeyValuePair<string, string>(
                            $"{name}[{entry.Key}]",
                            EncodeFormValueToString(entry.Value)
                        );
                    }
                }
                else
                {
                    var encodedValue = EncodeFormValueToString(value);
                    if (encodedValue != null)
                    {
                        yield return new KeyValuePair<string, string>(name, encodedValue);
                    }
                }
            }
        }

        string EncodeFormValueToString(object value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            string str;
            Type type = value.GetType();
            if (value is DateTime)
            {
                str = ((DateTime)value).ToString("yyyy-MM-dd'T'HH:mm:ssZ");

            }
            else if (value is string)
            {
                str = (string)value;

            }
            else if (value is bool)
            {
                str = value.ToString().ToLower();

            }
            else if (type.GetTypeInfo().IsEnum)
            {
                str = enumConverter.ToSerializedString(value.GetType(), value);

            }
            else
            {
                str = value.ToString();
            }

            return str;
        }
    }
}