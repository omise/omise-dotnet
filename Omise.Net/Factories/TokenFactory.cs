using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
	public class TokenFactory: GenericFactory<Token>
	{
		public TokenFactory ()
		{
		}

		public override Token Create (string json)
		{
			if (string.IsNullOrEmpty (json))
				throw new InvalidOperationException ("JSON Data is required for object mapping.");
			var obj = JsonConvert.DeserializeObject<Token>(json);
			var jsonObject = JObject.Parse(json);
			obj.Card = jsonObject.SelectToken ("card").ToObject<Card> ();
			return obj;
		}
	}
}

