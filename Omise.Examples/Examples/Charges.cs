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

        public async Task Retrieve__Retrieve_With_PlatformFee()
        {
            var chargeId = ExampleInfo.CHARGE_ID; // "chrg_test_5aass1sz7sdgaoi6zg8";
            var customHeaders = new Dictionary<string, string>
            {
                { "SUB_MERCHANT_ID", "team_123" },
            };
            var charge = await Client.Charges.Get(chargeId, customHeaders);
            Console.WriteLine($"charge amount: {charge.Amount} ${charge.PlatformFee.Amount}");
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

        public async Task Create__Create_With_Token_And_PlatFormFee()
        {
            var token = await RetrieveToken();
            var customHeaders = new Dictionary<string, string>
            {
                { "SUB_MERCHANT_ID", "team_123" },
            };
            var charge = await Client.Charges.Create(new CreateChargeRequest
            {
                Amount = 2000,
                Currency = "thb",
                Card = token.Id,
                Metadata = new Dictionary<string, object>
                {
                    { "order_id", "123" }
                },
                PlatformFee = new PlatformFeeRequest { Fixed = 10, Percentage = 1 }
            },customHeaders);

            Console.WriteLine($"created charge: {charge.Id} {charge.PlatformFee.Amount}");
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
                ExpiresAt = DateTime.Now.AddDays(2).ToUniversalTime()
            });

            Console.WriteLine($"created charge: {charge.Id} {charge.ExpiresAt}");
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

        public async Task Create__Create_With_WebhookEndpoints()
        {
            var customerId = ExampleInfo.CUST_ID_2; // "cust_test_5aass48w2i40qa5ivh9";
            var charge = await Client.Charges.Create(new CreateChargeRequest
            {
                Amount = 2000,
                Currency = "thb",
                Customer = customerId,
                WebhookEndpoints= new string[] { "https://webhook.site/123" }
            });

            Console.WriteLine($"created charge with webhooks: {charge.Id}");
        }

        public async Task Capture__Capture()
        {
            var charge = RetrieveUncapturedCharge();
            charge = await Client.Charges.Capture(charge.Id);
            Console.WriteLine($"captured charge: ({charge.Paid}) {charge.Id}");
        }

        public async Task Capture__Capture__Partial()
        {
            var charge = RetrieveUncapturedCharge(authType:AuthTypes.PreAuth);
            charge = await Client.Charges.Capture(charge.Id,new CaptureChargeRequest{CaptureAmount = 3000});
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

        protected Charge RetrieveUncapturedCharge(AuthTypes authType)
        {
            var token = RetrieveToken().Result;
            var charge = Client.Charges.Create(new CreateChargeRequest
            {
                Amount = 4000,
                Currency = "thb",
                Capture = false,
                Card = token.Id,
                AuthorizationType = authType
            }).Result;

            return charge;
        }
        #endregion

        #region PaymentSources

        #region Internet Banking
        public async Task Create__Create_With_Source_InternetBanking()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "thb",
                    Type = OffsiteTypes.InternetBankingBAY,
                    Flow = FlowTypes.Redirect
                },
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

        #region Mobile Banking
        public async Task Create__Create_With_Source_MobileBankingSCB()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "thb",
                    Type = OffsiteTypes.MobileBankingSCB,
                },
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

        #region ShopeePay
        public async Task Create__Create_With_Source_ShopeePay()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "thb",
                    Type = OffsiteTypes.ShopeePay,
                },
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
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "thb",
                    Type = OffsiteTypes.BillPaymentTescoLotus,
                    Flow = FlowTypes.Offline
                }
            });

            Console.WriteLine($"created charge: {charge.Id}");
            Console.WriteLine($"Barcode for customer: {charge.Source.References.Barcode}");
        }
        #endregion

        #region Rabbit Linepay
        public async Task Create__Create_With_Source_RabbitLinepay()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "thb",
                    Type = OffsiteTypes.RabbitLinepay,
                    Flow = FlowTypes.Redirect
                }
            });

            Console.WriteLine($"created charge: {charge.Id}");
            Console.WriteLine($"Redirect customer to: {charge.AuthorizeURI}");
        }

        #region WeChat Pay
        public async Task Create__Create_With_Source_WeChatPay()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "thb",
                    Ip = "127.0.0.1",
                    Type = OffsiteTypes.WeChatPay,
                    Flow = FlowTypes.Redirect
                }
            });

            Console.WriteLine($"created charge: {charge.Id}");
            Console.WriteLine($"Redirect customer to: {charge.AuthorizeURI}");
        }
        #endregion

        #endregion

        #region Wallet Alipay
        public async Task Create__Create_With_Wallet_Alipay()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Description = "Test product",
                Source = new CreatePaymentSourceRequest()
                {
                    Type = OffsiteTypes.BarcodeAlipay,
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

        #region TrueMoney
        public async Task Create__Create_With_Source_TrueMoney()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "thb",
                    Type = OffsiteTypes.TrueMoney,
                    PhoneNumber = "0812345678"
                }
            });

            Console.WriteLine($"created charge: {charge.Id}");
            Console.WriteLine($"phone number {charge.Source.PhoneNumber}");
        }
        #endregion

        #region
        public async Task Create__Create_With_Source_Fpx()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "myr",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "myr",
                    Type = OffsiteTypes.Fpx,
                    Email = "example@omise.co",
                    Bank = "cimb"
                }
            });

            Console.WriteLine($"created charge: {charge.Id}");
            Console.WriteLine($"email {charge.Source.Email}");
            Console.WriteLine($"bank {charge.Source.Bank}");
        }
        #endregion

        #region
        public async Task Create__Create_With_Source_AlipayCN()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "sgd",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "sgd",
                    Type = OffsiteTypes.AlipayCN,
                    PlatformType = PlatformTypes.Web,
                    Email = "example@omise.co",
                },
                ReturnUri = "https://www.example.com"
            });

            Console.WriteLine($"created charge: {charge.Id}");
            Console.WriteLine($"email {charge.Source.Email}");
            Console.WriteLine($"platform {charge.Source.PlatformType}");
        }
        #endregion

        #region AlipayPlusUPM
        public async Task Create__Create_With_Source_AlipayUPM()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "sgd",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "sgd",
                    Type = OffsiteTypes.AlipayPlusUPM,
                    PlatformType = PlatformTypes.Web,
                    Email = "example@omise.co",
                    Barcode = "2897991359827699709"
                },
                ReturnUri = "https://www.example.com"
            });

            Console.WriteLine($"created charge: {charge.Id}");
        }
        #endregion

        #region AlipayPlusMPM
        public async Task Create__Create_With_Source_AlipayMPM()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "sgd",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "sgd",
                    Type = OffsiteTypes.AlipayPlusMPM,
                    PlatformType = PlatformTypes.Web,
                    Email = "example@omise.co",
                },
                ReturnUri = "https://www.example.com"
            });

            Console.WriteLine($"created charge: {charge.Id}");
        }
        #endregion

        #region
        public async Task Create__Create_With_Source_OCBCPAO()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "sgd",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "sgd",
                    Type = OffsiteTypes.MobileBankingOCBCPAO,
                    PlatformType = PlatformTypes.iOS,
                },
                ReturnUri = "https://www.example.com"
            });

            Console.WriteLine($"created charge: {charge.Id}");
            Console.WriteLine($"platform {charge.Source.PlatformType}");
        }
        #endregion

        #endregion
        
        #region
        public async Task Create__Create_With_Source_PromptPay()
        {
            var charge = await Client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Source = new CreatePaymentSourceRequest
                {
                    Amount = 2000,
                    Currency = "thb",
                    Type = OffsiteTypes.PromptPay,
                    PlatformType = PlatformTypes.Web,
                    Email = "example@omise.co",
                },
                ReturnUri = "https://www.example.com",
                ExpiresAt = DateTime.Now.AddHours(11),
            });

            Console.WriteLine($"created charge: {charge.Id} {charge.ExpiresAt}");
            Console.WriteLine($"platform {charge.Source.PlatformType}");
        }
        #endregion
    }
}
