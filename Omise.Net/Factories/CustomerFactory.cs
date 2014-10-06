using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Omise
{
	public class CustomerFactory:GenericFactory<Customer>
	{
		public CustomerFactory ()
		{
		}

		public override Customer Create (string json)
		{
			if (string.IsNullOrEmpty (json))
				throw new InvalidOperationException ("JSON Data is required for object mapping.");
			var obj = JsonConvert.DeserializeObject<Customer>(json);
			var jsonObject = JObject.Parse(json);
			obj.CardCollection = new CardFactory().CreateCollection(jsonObject.SelectToken ("cards").ToString());//jsonObject.SelectToken ("cards.data").ToObject<ICollection<Card>> ();
			return obj;
		}
	}
}

