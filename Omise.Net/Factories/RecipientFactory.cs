using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Omise
{
    /// <summary>
    /// Factory object defines methods for creating Recipient object from api response
    /// </summary>
    public class RecipientFactory: GenericFactory<Recipient>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.RecipientFactory"/> class.
        /// </summary>
        public RecipientFactory()
        {
        }

        /// <summary>
        /// Create the Recipient object from JSON string
        /// </summary>
        /// <param name="json">Json string</param>
        public override Recipient Create(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException("json");
            var obj = JsonConvert.DeserializeObject<Recipient>(json);
            var jsonObject = JObject.Parse(json);
            //var bankAccountJson = jsonObject.SelectToken("bank_account");
            //if (bankAccountJson != null)
            //{
            //    obj.BankAccount = new BankAccountFactory().Create(bankAccountJson.ToString());
            //}
            return obj;
        }

        /// <summary>
        /// Creates charge collection from json string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public override CollectionResponseObject<Recipient> CreateCollection(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException("json");
            var jsonObject = JObject.Parse(json);
            var obj = JsonConvert.DeserializeObject<CollectionResponseObject<Recipient>>(json);
            if (jsonObject.SelectToken("data") != null)
            {
                obj.Collection = new List<Recipient>();
                var dataObject = jsonObject.SelectToken("data");
                foreach (var recipientJson in dataObject)
                {
                    var recipient = this.Create(recipientJson.ToString());
                    obj.Collection.Add(recipient);
                }
            }

            return obj;
        }
    }
}

