using System;
using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Examples
{
    public abstract class Example
    {
        public const string OMISE_PKEY = "pkey_test_59yny1yz6bxq5gfkbf1";
        public const string OMISE_SKEY = "skey_test_59yny2e94mwhyr1lp7h";

        protected Client Client { get; private set; }

        public Example()
        {
            this.Client = new Client(OMISE_PKEY, OMISE_SKEY);
            this.Client.APIVersion = "2017-11-02";
        }

        // actually creates a new token, named RetrieveToken() so merchant read
        // this as an example call to get token from cient-side.
        protected async Task<Token> RetrieveToken()
        {
            return await Client.Tokens.Create(new CreateTokenRequest
            {
                Name = "Somchai Prasert",
                Number = "4242424242424242",
                ExpirationMonth = DateTime.Now.Month,
                ExpirationYear = DateTime.Now.Year + 10,
            });
        }

        // Creates a new PaymentSource called RetrieveSourceInternetBanking, as sources can be created client-side (as well as server-side).
        protected async Task<PaymentSource> RetrieveSourceInternetBanking()
        {
            return await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Type = OffsiteTypes.InternetBankingBAY,
                Flow = FlowTypes.Redirect
            });
        }

        // Creates a new PaymentSource called RetrieveSourceBillPayment, as sources can be created client-side (as well as server-side).
        protected async Task<PaymentSource> RetrieveSourceBillPayment()
        {
            return await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Type = OffsiteTypes.BillPaymentTescoLotus,
                Flow = FlowTypes.Offline
            });
        }

    }
}
