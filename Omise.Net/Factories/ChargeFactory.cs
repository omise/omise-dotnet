using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Omise
{
    /// <summary>
    /// Factory object defines methods for creating charge object from api response
    /// </summary>
    public class ChargeFactory : GenericFactory<Charge>
    {
        /// <summary>
        /// Initialize the factory
        /// </summary>
        public ChargeFactory()
        {
        }

        /// <summary>
        /// Create a charge object from json string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public override Charge Create(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException(json);
            var obj = JsonConvert.DeserializeObject<Charge>(json);
            var jsonObject = JObject.Parse(json);
            var refundsJson = jsonObject.SelectToken("refunds");
            if (refundsJson != null)
            {
                obj.RefundCollection = new RefundFactory().CreateCollection(refundsJson.ToString());
            }
            return obj;
        }

        /// <summary>
        /// Creates charge collection from json string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public override CollectionResponseObject<Charge> CreateCollection(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException("json");
            var jsonObject = JObject.Parse(json);
            var obj = JsonConvert.DeserializeObject<CollectionResponseObject<Charge>>(json);
            if (jsonObject.SelectToken("data") != null)
            {
                obj.Collection = new List<Charge>();
                var dataObject = jsonObject.SelectToken("data");
                foreach(var chargeJson in dataObject){
                    var charge = this.Create(chargeJson.ToString());
                    obj.Collection.Add(charge);
                }
            }

            return obj;
        }
    }
}

