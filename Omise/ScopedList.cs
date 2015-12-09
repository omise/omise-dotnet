using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace Omise {
    public class ScopedList<T> : IEnumerable<T> {
        IList<T> data;

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("from")]
        public DateTime From { get; set; }

        [JsonProperty("to")]
        public DateTime To { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        // TODO: "total" JSON field?
        [JsonIgnore]
        public int Count { get { return data?.Count; } }

        [JsonProperty("data")]
        public IList<T> Data {
            get { return data; }
            set { data = new ReadOnlyCollection<T>(value); }
        }

        public T this[int indexer] {
            get { return data[indexer]; }
            set { data[indexer] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return (Data ?? Enumerable.Empty<T>()).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return (Data ?? Enumerable.Empty<T>()).GetEnumerator();
        }
    }
}

