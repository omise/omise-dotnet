using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace Omise.Models {
    public class Event : ModelBase {
        ModelBase data;

        public string Key { get; set; }

        [JsonProperty("data")]
        public JRaw RawDataJson { get; set; }

        [JsonIgnore]
        public ModelBase Data {
            get { return data = data ?? DeserializeDataByKey(); }
        }

        ModelBase DeserializeDataByKey() {
            var parts = Key.Split('.');
            var modelType = ModelTypes.TypeFor(parts[0]);
            var instance = (ModelBase)Activator.CreateInstance(modelType);

            var serializer = new Serializer();
            var json = (string)RawDataJson.Value;
            serializer.JsonPopulate(json, instance);
            return instance;
        }
    }


    // HACK: Workaround Newtonsoft.Json not giving us a choice to partially deserialize.
    // REF: http://stackoverflow.com/a/11223607/3055
    public class RawJsonConverter : JsonConverter {
        public override bool CanRead { get { return false; } }
        public override bool CanWrite { get { return false; } }

        public override bool CanConvert(Type objectType) {
            return true;
        }

        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer) {
            return JObject.Load(reader).ToString();
        }
    }
}

