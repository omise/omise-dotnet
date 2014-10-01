using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Omise
{
	public abstract class GenericFactory<T> where T : class
	{
		public GenericFactory ()
		{
		}

		public virtual T Create(string json){
			if (string.IsNullOrEmpty (json))
				throw new InvalidOperationException ("JSON Data is required for object mapping.");
			return JsonConvert.DeserializeObject<T>(json);
		}

		public virtual CollectionResponseObject<T> CreateCollection(string json){
			var jsonObject = JObject.Parse(json);
			var obj = JsonConvert.DeserializeObject<CollectionResponseObject<T>>(json);
			if (jsonObject.SelectToken ("data") != null) {
				obj.Collection = jsonObject.SelectToken ("data").ToObject<ICollection<T>> ();
			}
			return obj;
		}
	}
}

