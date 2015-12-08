using System;
using System.IO;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Versioning;
using System.Text;

namespace Omise {
    public sealed class Serializer {
        readonly JsonSerializer jsonSerializer;

        public Serializer() {
            jsonSerializer = new JsonSerializer();
            jsonSerializer.Converters.Add(new StringEnumConverter());
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

                    var value = prop.GetValue(payload, null);
                    writer.Write(EncodeFormValue(value));
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

        public void JsonPopulate(string json, object target) {
            var buffer = Encoding.UTF8.GetBytes(json);

            using (var stream = new MemoryStream(buffer))
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader)) {
                jsonSerializer.Populate(jsonReader, target);
            }
        }


        public static string EncodeFormValue(object value) {
            string str;
            if (value is DateTime) {
                str = ((DateTime)value).ToString("yyyy-MM-dd'T'HH:mm:ssZ");
            } else if (value is string) {
                str = (string)value;
            } else {
                str = value.ToString();
            }

            return Uri.EscapeDataString(str);
        }
    }
}

