using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Omise.Models;

namespace Omise
{
    [JsonObject]
    public abstract class ListBase<T> : IEnumerable<T>
    {
        IList<T> data;

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("order")]
        public Ordering order { get; set; }

        [JsonProperty("data")]
        public IList<T> Data
        {
            get { return data; }
            set { data = new ReadOnlyCollection<T>(value); }
        }

        public T this[int indexer]
        {
            get { return data[indexer]; }
            set { data[indexer] = value; }
        }

        // TODO: "total" JSON field?
        [JsonIgnore]
        public int Count => data?.Count ?? 0;

        IEnumerator IEnumerable.GetEnumerator() => (Data ?? Enumerable.Empty<T>()).GetEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => (Data ?? Enumerable.Empty<T>()).GetEnumerator();
    }
}

