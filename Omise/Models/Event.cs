using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Omise.Models
{
    /// <summary>
    /// Event object
    ///
    /// <a href="https://www.omise.co/events-api">Event API</a>
    /// </summary>
    public partial class Event : ModelBase
    {
        [JsonIgnore]
        public ModelBase Data => data = data ?? DeserializeDataByKey();
        ModelBase data;
        [JsonProperty("data")]
        public JRaw RawDataJson { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("webhook_deliveries")]
        public List<IDictionary<string, object>> WebhookDeliveries { get; set; }

        public ModelBase DeserializeDataByKey() {
            var parts = Key.Split('.');
            var modelType = ModelTypes.TypeFor(parts[0]);
            var instance = (ModelBase)System.Activator.CreateInstance(modelType);

            var serializer = new Serializer();
            var json = (string)RawDataJson.Value;
            serializer.JsonPopulate(json, instance);
            return instance;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Event;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Data, another.Data) &&
                object.Equals(this.RawDataJson, another.RawDataJson) &&
                object.Equals(this.Key, another.Key) &&
                object.Equals(this.WebhookDeliveries, another.WebhookDeliveries) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Data != default(ModelBase)) {
                    hash = hash * 23 + Data.GetHashCode();
                }
                if (RawDataJson != default(JRaw)) {
                    hash = hash * 23 + RawDataJson.GetHashCode();
                }
                if (Key != default(string)) {
                    hash = hash * 23 + Key.GetHashCode();
                }
                if (WebhookDeliveries != default(List<IDictionary<string, object>>)) {
                    hash = hash * 23 + WebhookDeliveries.GetHashCode();
                }

                return hash;
            }
        }
    }
}