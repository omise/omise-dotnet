using NUnit.Framework.Internal;
using NUnit.Framework;
using Omise;
using Omise.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Omise.Tests.ManualTesting
{
    [TestFixture, Explicit("code provided for manual testing only.")]
    public class RealNetworkTest : OmiseTest
    {
        const string PublicKey = "pkey";
        const string SecretKey = "skey";
        string cardToken = "";
        string cardToken2 = "";
        string chargeId = "";
        string recipientId = "";
        string customerId = "";
        string transferId = "";
        readonly Client client = new Client(pkey: PublicKey, skey: SecretKey, env: Environments.Staging);

        [Test, Order(1)]
        public async Task Create_Token_Full_Request()
        {
            var token = await client.Tokens.Create(new CreateTokenRequest
            {
                Name = "Omise Co., Ltd",
                Number = "4242424242424242",
                SecurityCode = "123",
                ExpirationMonth = 10,
                ExpirationYear = 2029,
                City = "City",
                Country = "TH",
                Email = "test@gmail.com",
                PhoneNumber = "0745123498",
                PostalCode = "18321",
                State = "State",
                Street1 = "Street1",
                Street2 = "Street2"
            });
            cardToken = token.Id;
            Console.WriteLine($"created token: {token.Id}");
        }

        [Test, Order(2)]
        public async Task Create_Token_Min_Request()
        {
            var token = await client.Tokens.Create(new CreateTokenRequest
            {
                Number = "4242424242424242",
                SecurityCode = "123",
                ExpirationMonth = 10,
                ExpirationYear = 2029,
                Name = "Name"
            });
            cardToken2 = token.Id;
            Console.WriteLine($"created token: {token.Id}");
        }

        [Test, Order(3)]
        public async Task Create_Source_Full_Request()
        {
            var source = await client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Barcode = "Barcode",
                Billing = new Billing() { City = "City", Country = "TH", PostalCode = "18321", State = "State", Street1 = "Streets1", Street2 = "Street2" },
                Currency = "THB",
                PlatformType = PlatformTypes.Web,
                Email = "test@gmail.com",
                Flow = FlowTypes.Redirect,
                Ip = "10.0.0.2",
                InstallmentTerm = "3",
                Items = new List<Item> { new Item { Amount = 2000, Brand = "TestBrand", Sku = "Sku", Category = "Category", ImageUri = "https://www.opn.ooo/", ItemUri = "https://www.opn.ooo/", Name = "Name", Quantity = 4, } },
                PhoneNumber = "0745123498",
                Name = "Name",
                PromotionCode = "code",
                Shipping = new Shipping() { City = "City", Country = "TH", PostalCode = "18321", State = "State", Street1 = "Streets1", Street2 = "Street2" },
                StoreId = "storeId",
                StoreName = "storeName",
                TerminalId = "terminalId",
                Type = OffsiteTypes.PromptPay,
                Bank = "bank"
            });
            Console.WriteLine($"created source: {source.Id}");
        }

        [Test, Order(4)]
        public async Task Create_Source_Min_Request()
        {
            var source = await client.Sources.Create(new CreatePaymentSourceRequest
            {
                Currency = "THB",
                Type = OffsiteTypes.PromptPay,
            });
            Console.WriteLine($"created source: {source.Id}");
        }

        [Test, Order(5)]
        public async Task Create_Charge_Full_Request_With_Token_Card()
        {

            var charge = await client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                AuthorizationType = AuthTypes.FinalAuth,
                ReturnUri = "https://www.example.com",
                Capture = true,
                Card = cardToken,
                Description = "Description",
                ExpiresAt = DateTime.Now.AddMinutes(10),
                Ip = "10.0.0.2",
                Metadata = new Dictionary<string, object>
                {
                    { "order_id", "123" }
                },
                TransactionIndicator = "MIT",
                ZeroInterestInstallments = true,
                WebhookEndpoints = new string[] { "https://webhook.site/123" },
                PlatformFee = new PlatformFeeRequest()
                {
                    Fixed = 0,
                    Percentage = 0,
                }
            });

            Console.WriteLine($"created charge: {charge.Id}");
        }
        [Test, Order(6)]
        public async Task Create_Charge_Min_Request_With_Card_Token()
        {

            var charge = await client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                AuthorizationType = AuthTypes.FinalAuth,
                Card = cardToken2
            });
            chargeId = charge.Id;
            Console.WriteLine($"created charge: {charge.Id}");

        }
        public async Task Create_Charge_Full_Request_With_Source()
        {

            var charge = await client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                AuthorizationType = AuthTypes.FinalAuth,
                ReturnUri = "https://www.example.com",
                Capture = true,
                Source = new PaymentSource
                {
                    Amount = 2000,
                    Barcode = "Barcode",
                    Currency = "THB",
                    Email = "test@gmail.com",
                    Flow = FlowTypes.Redirect,
                    Ip = "10.0.0.2",
                    StoreId = "storeId",
                    StoreName = "storeName",
                    TerminalId = "terminalId",
                    Type = OffsiteTypes.PromptPay,
                    Bank = "bank"
                },
                Description = "Description",
                ExpiresAt = DateTime.Now.AddMinutes(10),
                Ip = "10.0.0.2",
                Metadata = new Dictionary<string, object>
                {
                    { "order_id", "123" }
                },
                TransactionIndicator = "MIT",
                ZeroInterestInstallments = true,
                WebhookEndpoints = new string[] { "https://webhook.site/123" },
            });

            Console.WriteLine($"created charge: {charge.Id}");
        }
        [Test, Order(7)]
        public async Task Create_Refund_Full_Params()
        {

            var refund = await client.Charge(chargeId).Refunds.Create(new CreateRefundRequest
            {
                Amount = 2000,
                Metadata = new Dictionary<string, object>
                {
                    { "order_id", "123" }
                },
                Void = true
            });

            Console.WriteLine($"created refund: {refund.Id}");

        }
        [Test, Order(7)]
        public async Task Create_Recipient_Full_Params()
        {

            var recipient = await client.Recipients.Create(new CreateRecipientRequest
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Description = "John Doe (user: 30)",
                Type = RecipientType.Individual,
                BankAccount = new BankAccountRequest
                {
                    Brand = "kbank",
                    Number = "7777777777",
                    Name = "Dohn Joe",
                },
            });
            recipientId = recipient.Id;
            Console.WriteLine($"created recipient: {recipient.Id}");

        }
        [Test, Order(8)]
        public async Task Create_Transfer_Full_Params()
        {

            var transfer = await client.Transfers.Create(new CreateTransferRequest
            {
                Amount = 4000,
                FailFast = false,
                IdempKey = Guid.NewGuid().ToString(),
                Metadata = new Dictionary<string, object>
                {
                    { "order_id", "123" }
                },
                Recipient = recipientId,
                SplitTransfer = false

            });
            transferId = transfer.Id;
            Console.WriteLine($"created transfer: {transfer.Id}");

        }
        [Test, Order(9)]
        public async Task Create_Customer_No_Card()
        {

            var customer = await client.Customers.Create(new CreateCustomerRequest
            {
                Email = "john.doe@example.com",
                Description = "John Doe (id: 30)",
                Metadata = new Dictionary<string, object>
                {
                    { "user_id", 30 }
                },
            });

            Console.WriteLine($"created customer: {customer.Id}");

        }
        [Test, Order(10)]
        public async Task Create_Customer_With_Card()
        {
            var token = await client.Tokens.Create(new CreateTokenRequest
            {
                Number = "4242424242424242",
                SecurityCode = "123",
                ExpirationMonth = 10,
                ExpirationYear = 2029,
                Name = "Name"
            });
            var customer = await client.Customers.Create(new CreateCustomerRequest
            {
                Email = "john.doe@example.com",
                Description = "John Doe (id: 30)",
                Metadata = new Dictionary<string, object>
                {
                    { "user_id", 30 }
                },
                Card = token.Id
            });
            customerId = customer.Id;
            Console.WriteLine($"created customer: {customer.Id}");

        }
        [Test, Order(11)]
        public async Task Create_Charge_Full_Request_With_Customer()
        {

            var charge = await client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                AuthorizationType = AuthTypes.FinalAuth,
                ReturnUri = "https://www.example.com",
                Capture = true,
                Customer = customerId,
                Description = "Description",
                ExpiresAt = DateTime.Now.AddMinutes(10),
                Ip = "10.0.0.2",
                Metadata = new Dictionary<string, object>
                {
                    { "order_id", "123" }
                },
                TransactionIndicator = "MIT",
                ZeroInterestInstallments = true,
                WebhookEndpoints = new string[] { "https://webhook.site/123" },
            });

            Console.WriteLine($"created charge: {charge.Id}");
        }
        [Test, Order(13)]
        public async Task Get_disputes_based_on_status()
        {

            var resource = client.Disputes.ClosedDisputes;
            var closedDisputes = await resource.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"closed disputes: {closedDisputes.Total}");
            resource = client.Disputes.OpenDisputes;
            var openDisputes = await resource.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"open disputes: {openDisputes.Total}");

        }
        [Test, Order(14)]
        public async Task Create_link()
        {

            var link = await client.Links.Create(new CreateLinkRequest
            {
                Amount = 2000,
                Currency = "thb",
                Title = "that shirt.",
                Description = "that shirt.",
                Multiple = false
            });

            Console.WriteLine($"payment link: {link.PaymentURI}");

        }
        [Test, Order(15)]
        public async Task Create_Scheduled_Charge()
        {

            var schedule = await client.Schedules.Create(new CreateScheduleRequest
            {
                Every = 2,
                Period = SchedulePeriod.Day,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                On = new ScheduleOnRequest
                {
                    Weekdays = new[] { Weekdays.Monday },
                },
                Charge = new ChargeScheduling
                {
                    Amount = 2000,
                    Currency = "thb",
                    Customer = customerId,
                },
                Transfer = new TransferScheduling()
                {
                    Amount = 4000,
                    PercentageOfBalance = 3,
                    Recipient = recipientId
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");

        }

    }
}
