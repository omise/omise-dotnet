using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Omise
{
    /// <summary>
    /// Factory object defines methods for creating customer object from api response
    /// </summary>
    public class CustomerFactory : GenericFactory<Customer>
    {
        /// <summary>
        /// Initialize the factory
        /// </summary>
        public CustomerFactory()
        {
        }

        /// <summary>
        /// Creates a Customer object from json string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public override Customer Create(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException(json);
            var obj = JsonConvert.DeserializeObject<Customer>(json);
            var jsonObject = JObject.Parse(json);
            var cardsJson = jsonObject.SelectToken("cards");
            if (cardsJson != null)
            {
                obj.CardCollection = new CardFactory().CreateCollection(cardsJson.ToString());
            }
            return obj;
        }
    }
}

