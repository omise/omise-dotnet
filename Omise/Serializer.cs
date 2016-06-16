using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Omise {
    public sealed class Serializer {
        readonly JsonSerializer jsonSerializer;

        public Serializer() {
            jsonSerializer = new JsonSerializer();
            jsonSerializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializer.Converters.Add(new StringEnumConverter { CamelCaseText = true });
            jsonSerializer.NullValueHandling = NullValueHandling.Ignore;
        }

        public void JsonSerialize<T>(Stream target, T payload) where T : class {
            using (var writer = new StreamWriter(target))
            using (var jsonWriter = new JsonTextWriter(writer)) {
                jsonSerializer.Serialize(jsonWriter, payload);
            }
        }

        public T JsonDeserialize<T>(Stream target) where T : class {
            using (var reader = new StreamReader(target))
            using (var jsonReader = new JsonTextReader(reader)) {
                return jsonSerializer.Deserialize<T>(jsonReader);
            }
        }

        public void JsonPopulate(string json, object target) {
            var buffer = Encoding.UTF8.GetBytes(json);

            using (var stream = new MemoryStream(buffer))
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader)) {
                jsonSerializer.Populate(jsonReader, target);
            }
        }


        public FormUrlEncodedContent ExtractFormValues(object payload) {
            var values = ExtractFormValues(payload, null);
            return new FormUrlEncodedContent(values);
        }

        IEnumerable<KeyValuePair<string, string>> ExtractFormValues(
            object payload,
            string prefix
        ) {
            var clrAsm = typeof(object).Assembly;
            var props = payload
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props) {
                var value = prop.GetValue(payload, null);
                if (value == null) continue;

                var name = prop.GetCustomAttributes(true)
                    .Where(obj => obj is JsonPropertyAttribute)
                    .Cast<JsonPropertyAttribute>()
                    .Select(attr => attr.PropertyName)
                    .FirstOrDefault() ??
                           prop.Name.ToLower();

                if (!string.IsNullOrEmpty(prefix)) {
                    name = $"{prefix}[{name}]";
                }

                var type = value.GetType();
                if (type.IsClass && type.Assembly != clrAsm) {
                    foreach (var result in ExtractFormValues(value, name)) {
                        yield return result;
                    }

                }
                else {
                    var encodedValue = EncodeFormValueToString(value);
                    yield return new KeyValuePair<string, string>(name, encodedValue);
                }
            }
        }

        static string EncodeFormValueToString(object value) {
            if (value == null) throw new ArgumentNullException(nameof(value));

            string str;
            Type type = value.GetType();
            if (value is DateTime) {
                str = ((DateTime)value).ToString("yyyy-MM-dd'T'HH:mm:ssZ");

            }
            else if (value is string) {
                str = (string)value;

            }
            else if (value is bool) {
                str = value.ToString().ToLower();

            }
            else if (type.IsEnum) {
                var member = type.GetMember(value.ToString())[0];
                var attributes = member.GetCustomAttributes(typeof(EnumMemberAttribute), true);
                if (attributes.Length > 0) {
                    str = ((EnumMemberAttribute)attributes[0]).Value;
                }
                else {
                    str = value.ToString();
                }

            }
            else {
                str = value.ToString();
            }

            return str;
        }
    }
}