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

        /// <summary>
        /// Creates customer collection from json string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public override CollectionResponseObject<Customer> CreateCollection(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException("json");
            var jsonObject = JObject.Parse(json);
            var obj = JsonConvert.DeserializeObject<CollectionResponseObject<Customer>>(json);
            if (jsonObject.SelectToken("data") != null)
            {
                obj.Collection = new List<Customer>();
                var dataObject = jsonObject.SelectToken("data");
                foreach (var customerJson in dataObject)
                {
                    var customer = this.Create(customerJson.ToString());
                    obj.Collection.Add(customer);
                }
            }

            return obj;
        }
    }
}

