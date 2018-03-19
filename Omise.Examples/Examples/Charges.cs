using Omise.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace Omise.Examples
{
    public class Charges : Example
    {
        public async Task List__List()
        {
            var charges = await Client.Charges.GetList(order: Ordering.Chronological);
            Console.WriteLine($"total charges: {charges.Total}");
        }

        public async Task Retrieve__Retrieve()
        {
            var chargeId = ExampleInfo.CHARGE_ID; // "chrg_test_5aass1sz7sdgaoi6zg8";
            var charge = await Client.Charges.Get(chargeId);
            Console.WriteLine($"charge amount: {charge.Amount}");
        }

        #region Cards
        public async Task Create__Create_With_Token()
        {
            var token = await RetrieveToken();
            var charge = await Client.Charges.Create(new CreateChargeRequest
            {
                Amount = 2000,
                Currency = "thb",
                Card = token.Id,
                Metadata = new Dictionary<string, object>
                {
                    { "order_id", "123" }
                },
            });

            Console.WriteLine($"created charge: {charge.Id}");
        }

        public async Task Create__Create_With_Card()
        {
            var customerId = ExampleInfo.CUST_ID_2; // "cust_test_5aass48w2i40qa5ivh9";
            var cardId = ExampleInfo.CARD_ID_2; // "card_test_5aasvrrz6vx42t74zux";
            var charge = await Client.Charges.Create(new CreateChargeRequest
            {
                Amount = 2000,
                Currency = "thb",
                Customer = customerId,
                Card = cardId,
            });

            Console.WriteLine($"created charge: {charge.Id}");
        }

        public async Task Create__Create_With_Customer()
        {
            var customerId = ExampleInfo.CUST_ID_2; // "cust_test_5aass48w2i40qa5ivh9";
            var charge = await Client.Charges.Create(new CreateChargeRequest
            {
                Amount = 2000,
                Currency = "thb",
                Customer = customerId,
            });

            Console.WriteLine($"created charge: {charge.Id}");
        }

        public async Task Capture__Capture()
        {
            var charge = RetrieveUncapturedCharge();
            charge = await Client.Charges.Capture(charge.Id);
            Console.WriteLine($"captured charge: ({charge.Paid}) {charge.Id}");
        }

        public async Task Reverse__Reverse()
        {
            var charge = RetrieveUncapturedCharge();
            charge = await Client.Charges.Reverse(charge.Id);
            Console.WriteLine($"reversed charge: ({charge.Reversed}) {charge.Id}");
        }

        public async Task Update__Update_Description()
        {
            var charge = RetrieveUncapturedCharge();
            charge = await Client.Charges.Update(charge.Id, new UpdateChargeRequest
            {
                Description = "hello",
                Metadata = new Dictionary<string, object>
                {
                    { "order_id", "123" },
                }
            });

            Console.WriteLine($"updated charge: {charge.Id} {charge.Description}");
        }

        protected Charge RetrieveUncapturedCharge()
        {
            var token = RetrieveToken().Result;
            var charge = Client.Charges.Create(new CreateChargeRequest
            {
                Amount = 2000,
                Currency = "thb",
                Capture = false,
                Card = token.Id,
            }).Result;

            return charge;
        }
        #endregion

        #region PaymentSources

        #region Internet Banking
        public async Task Create__Create_With_Source_InternetBanking()
        {
            var source = await RetrieveSourceInternetBanking();
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Offsite = OffsiteTypes.InternetBankingBAY,
                Flow = FlowTypes.Redirect,
                Source = source,
                ReturnUri = "https://www.omise.co/",
                Metadata = new Dictionary<string, object>
                {
                    { "invoice_id", "ABC1234" }
                }
            });

            Console.WriteLine($"created charge: {charge.Id}");
            Console.WriteLine($"redirect customer to {charge.AuthorizeURI}");
        }

        // TODO: handle the return from the bank
        #endregion

        #region Bill Payment
        public async Task Create__Create_With_Source_BillPayment()
        {
            var source = await RetrieveSourceBillPayment();
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Offsite = OffsiteTypes.BillPaymentTescoLotus,
                Flow = FlowTypes.Offline,
                Source = source
            });

            Console.WriteLine($"created charge: {charge.Id}");
            Console.WriteLine($"Barcode for customer: {charge.Source.References.Barcode}");
        }
        #endregion

        #region Wallet Alipay
        public async Task Create__Create_With_Wallet_Alipay()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Description = "Test product",
                Source = new PaymentSource()
                {
                    Type = OffsiteTypes.WalletAlipay,
                    Barcode = "201234567890",
                    StoreId = "Store1",
                    StoreName = "Store 1",
                    TerminalId = "0001"
                },
                Metadata = new Dictionary<string, object>
                {
                    { "invoice_id", "inv0001" }
                }
            });
        }

        public async Task Retrieve__Retrieve_Wallet_Alipay()
        {
            var chargeId = ExampleInfo.CHARGE_ID_WA; // "chrg_test_5aass1sz7sdgaoi6zg8";
            var charge = await Client.Charges.Get(chargeId);
            Console.WriteLine($"charge status: {charge.Status}");
        }
        #endregion

        #endregion
    }
}
