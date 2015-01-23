using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            var bankAccountsJson = jsonObject.SelectToken("bank_accounts");
            if (bankAccountsJson != null)
            {
                obj.BankAccountCollection = new BankAccountFactory().CreateCollection(bankAccountsJson.ToString());
            }
            return obj;
        }
    }
}

