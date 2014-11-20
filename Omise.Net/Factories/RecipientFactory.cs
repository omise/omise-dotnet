using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
    public class RecipientFactory: GenericFactory<Recipient>
    {
        public RecipientFactory()
        {
        }

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

