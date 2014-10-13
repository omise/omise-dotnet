using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Omise
{
    /// <summary>
    /// An abstract base class defines common behavior of the factory class for creating the object from api response
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public abstract class GenericFactory<T> where T : class
	{
        /// <summary>
        /// Initialize the object
        /// </summary>
		public GenericFactory ()
		{
		}

		/// <summary>
		/// Create the object from JSON string
		/// </summary>
		/// <param name="json">Json string</param>
		public virtual T Create(string json){
			if (string.IsNullOrEmpty (json))
				throw new ArgumentNullException ("json");
			return JsonConvert.DeserializeObject<T>(json);
		}

		/// <summary>
		/// Creates CollectionResponseObject object of specified type
		/// </summary>
		/// <returns>CollectionResponseObject of specified type</returns>
		/// <param name="json">Json string</param>
		public virtual CollectionResponseObject<T> CreateCollection(string json){
			if (string.IsNullOrEmpty (json))
				throw new ArgumentNullException ("json");
			var jsonObject = JObject.Parse(json);
			var obj = JsonConvert.DeserializeObject<CollectionResponseObject<T>>(json);
			if (jsonObject.SelectToken ("data") != null) {
				obj.Collection = jsonObject.SelectToken ("data").ToObject<ICollection<T>> ();
			}
			return obj;
		}
	}
}

