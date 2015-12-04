using System;
using System.IO;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;

namespace Omise {
    public sealed class Serializer {
        readonly JsonSerializer jsonSerializer;

        public Serializer() {
            jsonSerializer = new JsonSerializer();
        }

        public void FormSerialize<T>(Stream target, T payload) where T: class {
            using (var writer = new StreamWriter(target)) {
                var props = payload.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance);

                var firstValue = true;
                foreach (var prop in props) {
                    if (firstValue) {
                        firstValue = false;
                    } else {
                        writer.Write("&");
                    }

                    var name = prop.GetCustomAttributes(true)
                        .Where(obj => obj is JsonPropertyAttribute)
                        .Cast<JsonPropertyAttribute>()
                        .Select(attr => attr.PropertyName)
                        .FirstOrDefault() ??
                               prop.Name;
                    
                    writer.Write(name);
                    writer.Write("=");

                    var value = formatValue(prop.GetValue(payload, null));
                    writer.Write(Uri.EscapeUriString(value));
                }
            }
        }

        public void JsonSerialize<T>(Stream target, T payload) where T: class {
            using (var writer = new StreamWriter(target))
            using (var jsonWriter = new JsonTextWriter(writer)) {
                jsonSerializer.Serialize(jsonWriter, payload);
            }
        }

        public T JsonDeserialize<T>(Stream target) where T: class {
            using (var reader = new StreamReader(target))
            using (var jsonReader = new JsonTextReader(reader)) {
                return jsonSerializer.Deserialize<T>(jsonReader);
            }
        }


        string formatValue(object value) {
            if (value is DateTime) return ((DateTime)value).ToString("yyyy-MM-dd'T'HH:mm:ssZ");
            if (value is string) return (string)value;

            return value.ToString();
        }
    }
}

