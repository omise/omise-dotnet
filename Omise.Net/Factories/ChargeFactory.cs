using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

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
    }
}

