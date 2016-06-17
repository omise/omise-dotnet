using System;
using Newtonsoft.Json;

namespace Omise.Models {
    public partial class Event : ModelBase {
        ModelBase data;

        [JsonIgnore]
        public ModelBase Data => data = data ?? DeserializeDataByKey();

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
}
