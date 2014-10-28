using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
    /// <summary>
    /// Factory object defines methods for creating token object from api response
    /// </summary>
    public class TokenFactory : GenericFactory<Token>
    {
        /// <summary>
        /// Initialize the factory
        /// </summary>
        public TokenFactory()
        {
        }

        /// <summary>
        /// Creates a Token object from json string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public override Token Create(string json)
        {
            if (string.IsNullOrEmpty(json))
				throw new ArgumentNullException (json);
            var obj = JsonConvert.DeserializeObject<Token>(json);
            var jsonObject = JObject.Parse(json);
            obj.Card = jsonObject.SelectToken("card").ToObject<Card>();
            return obj;
        }
    }
}

