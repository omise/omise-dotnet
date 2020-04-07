using System;
using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Examples
{
    public abstract class Example
    {
        public const string OMISE_PKEY = ExampleInfo.OMISE_PKEY;
        public const string OMISE_SKEY = ExampleInfo.OMISE_SKEY;

        protected Client Client { get; private set; }

        public Example()
        {
            this.Client = new Client(OMISE_PKEY, OMISE_SKEY);
        }

        // actually creates a new token, named RetrieveToken() so merchant read
        // this as an example call to get token from cient-side.
        protected async Task<Token> RetrieveToken()
        {
            return await Client.Tokens.Create(new CardParams
            {
                Name = "Somchai Prasert",
                Number = "4242424242424242",
                ExpirationMonth = DateTime.Now.Month,
                ExpirationYear = DateTime.Now.Year + 10,
            });
        }

        // Creates a new PaymentSource called RetrieveSourceInternetBanking, as sources can be created client-side (as well as server-side).
        protected async Task<Source> RetrieveSourceInternetBanking()
        {
            return await Client.Sources.Create(new CreateSourceParams
            {
                Amount = 2000,
                Currency = "thb",
                Type = SourceType.InternetBankingBAY,
            });
        }

        // Creates a new PaymentSource called RetrieveSourceBillPayment, as sources can be created client-side (as well as server-side).
        protected async Task<Source> RetrieveSourceBillPayment()
        {
            return await Client.Sources.Create(new CreateSourceParams
            {
                Amount = 2000,
                Currency = "thb",
                Type = SourceType.BillPaymentTescoLotus,
            });
        }

        // Creates a new PaymentSource called RetrieveSourceBarcode, as sources can be created client-side (as well as server-side).
        protected async Task<Source> RetrieveSourceBarcode()
        {
            return await Client.Sources.Create(new CreateSourceParams
            {
                Type = SourceType.BarcodeAlipay,
                Barcode = "201234567890",
                StoreId = "Store1",
                StoreName = "Store 1",
                TerminalId = "0001"
            });
        }
    }
}
