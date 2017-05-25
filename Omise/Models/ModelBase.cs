using System;
using Newtonsoft.Json;

namespace Omise.Models
{
    public abstract class ModelBase
    {
        [JsonIgnore]
        public IRequester Requester { get; internal set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        // TODO: Provide Task<T> Reload() functionality.

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = (ModelBase)obj;

            return this.Object == another.Object &&
            this.Id == another.Id &&
            this.LiveMode == another.LiveMode &&
            this.Location == another.Location &&
            this.Created == another.Created &&
            this.Deleted == another.Deleted;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Object.GetHashCode();
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + LiveMode.GetHashCode();
                hash = hash * 23 + Location.GetHashCode();
                hash = hash * 23 + Created.GetHashCode();
                hash = hash * 23 + Deleted.GetHashCode();

                return hash;
            }
        }
    }
}