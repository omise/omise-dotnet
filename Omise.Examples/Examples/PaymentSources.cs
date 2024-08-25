using System;
using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Examples
{
    public class PaymentSources : Example
    {
        #region Internet Banking
        public async Task Create__Create_InternetBanking()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Type = OffsiteTypes.InternetBankingBAY,
                Flow = FlowTypes.Redirect
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_InternetBanking()
        {
            var sourceId = RetrieveInternetBankingSourceId();
            var source = await Client.Sources.Get(sourceId);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
        }

        protected string RetrieveInternetBankingSourceId()
        {
            return RetrieveSourceInternetBanking().Result.Id;
        }
        #endregion

        #region Rabbit Linepay
        public async Task Create__Create_RabbitLinepay()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Type = OffsiteTypes.RabbitLinepay,
                Flow = FlowTypes.Redirect
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_RabbitLinepay()
        {
            var sourceId = RetrieveRabbitLinepaySourceId();
            var source = await Client.Sources.Get(sourceId);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
        }

        protected string RetrieveRabbitLinepaySourceId()
        {
            return RetrieveSourceRabbitLinepay().Result.Id;
        }
        #endregion

        #region WeChat Pay
        public async Task Create__Create_WeChatPay()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Ip = "127.0.0.1",
                Type = OffsiteTypes.WeChatPay,
                Flow = FlowTypes.Redirect
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_WeChatPay()
        {
            var sourceId = RetrieveWeChatPaySourceId();
            var source = await Client.Sources.Get(sourceId);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
        }

        protected string RetrieveWeChatPaySourceId()
        {
            return RetrieveSourceWeChatPay().Result.Id;
        }
        #endregion

        #region BillPayment
        public async Task Create__Create_BillPayment()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Type = OffsiteTypes.BillPaymentTescoLotus,
                Flow = FlowTypes.Offline
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_BillPayment()
        {
            var sourceId = RetrieveBillPaymentSourceId();
            var source = await Client.Sources.Get(sourceId);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
        }

        protected string RetrieveBillPaymentSourceId()
        {
            return RetrieveSourceBillPayment().Result.Id;
        }
        #endregion

        #region TrueMoney
        public async Task Create__Create_TrueMoney()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Type = OffsiteTypes.TrueMoney,
                MobileNumber = "0812345678"
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_TrueMoney()
        {
            var sourceId = RetrieveTrueMoneySourceId();
            var source = await Client.Sources.Get(sourceId);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
        }

        protected string RetrieveTrueMoneySourceId()
        {
            return RetrieveSourceBillPayment().Result.Id;
        }
        #endregion

        #region Fpx
        public async Task Create__Create_Fpx()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "myr",
                Type = OffsiteTypes.Fpx,
                Email = "example@omise.co",
                Bank = "cimb"
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_Fpx()
        {
            var sourceID = RetrieveFpxSourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
        }

        protected string RetrieveFpxSourceId()
        {
            return RetrieveSourceFpx().Result.Id;
        }
        #endregion

        #region Alipay+
        #region AlipayCN
        public async Task Create__Create_AlipayCN()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "sgd",
                Type = OffsiteTypes.AlipayCN,
                PlatformType = PlatformTypes.Web,
                Email = "example@omise.co",
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_AlipayCN()
        {
            var sourceID = RetrieveAlipayCNSourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
            Console.WriteLine($"source platform is {source.PlatformType.ToString()}");
        }

        protected string RetrieveAlipayCNSourceId()
        {
            return RetrieveSourceAlipayCN().Result.Id;
        }

        #region AlipayHK
        public async Task Create__Create_AlipayHK()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "sgd",
                Type = OffsiteTypes.AlipayHK,
                PlatformType = PlatformTypes.Web,
                Email = "example@omise.co",
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_AlipayHK()
        {
            var sourceID = RetrieveAlipayHKSourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
            Console.WriteLine($"source platform is {source.PlatformType.ToString()}");
        }

        protected string RetrieveAlipayHKSourceId()
        {
            return RetrieveSourceAlipayHK().Result.Id;
        }

        #region AlipayPlusUPM
        public async Task Create__Create_AlipayPlusUPM()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Type = OffsiteTypes.AlipayPlusUPM,
                PlatformType = PlatformTypes.Web,
                Email = "example@omise.co",
                Barcode = "2897991359827699709"
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_AlipayPlusUPM()
        {
            var sourceID = RetrieveAlipayPlusUPMSourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
            Console.WriteLine($"source platform is {source.PlatformType.ToString()}");
        }

        protected string RetrieveAlipayPlusUPMSourceId()
        {
            return RetrieveSourceAlipayPlusUPM().Result.Id;
        }

        #endregion
        #region AlipayPlusMPM
        public async Task Create__Create_AlipayPlusMPM()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Type = OffsiteTypes.AlipayPlusMPM,
                PlatformType = PlatformTypes.Web,
                Email = "example@omise.co",
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_AlipayPlusMPM()
        {
            var sourceID = RetrieveAlipayPlusMPMSourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
            Console.WriteLine($"source platform is {source.PlatformType.ToString()}");
        }

        protected string RetrieveAlipayPlusMPMSourceId()
        {
            return RetrieveSourceAlipayPlusMPM().Result.Id;
        }

        #endregion
        #endregion

        #region DANA
        public async Task Create__Create_DANA()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "sgd",
                Type = OffsiteTypes.DANA,
                PlatformType = PlatformTypes.Web,
                Email = "example@omise.co",
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_DANA()
        {
            var sourceID = RetrieveDANASourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
            Console.WriteLine($"source platform is {source.PlatformType.ToString()}");
        }

        protected string RetrieveDANASourceId()
        {
            return RetrieveSourceDANA().Result.Id;
        }

        #endregion

        #region GCash
        public async Task Create__Create_GCash()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "sgd",
                Type = OffsiteTypes.GCash,
                PlatformType = PlatformTypes.Web,
                Email = "example@omise.co",
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_GCash()
        {
            var sourceID = RetrieveGCashSourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
            Console.WriteLine($"source platform is {source.PlatformType.ToString()}");
        }

        protected string RetrieveGCashSourceId()
        {
            return RetrieveSourceGCash().Result.Id;
        }

        #endregion

        #region KakaoPay
        public async Task Create__Create_KakaoPay()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "sgd",
                Type = OffsiteTypes.KakaoPay,
                PlatformType = PlatformTypes.Web,
                Email = "example@omise.co",
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_KakaoPay()
        {
            var sourceID = RetrieveKakaoPaySourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
            Console.WriteLine($"source platform is {source.PlatformType.ToString()}");
        }

        protected string RetrieveKakaoPaySourceId()
        {
            return RetrieveSourceKakaoPay().Result.Id;
        }

        #endregion

        #region TouchNGo
        public async Task Create__Create_TouchNGo()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "sgd",
                Type = OffsiteTypes.TouchNGo,
                PlatformType = PlatformTypes.Web,
                Email = "example@omise.co",
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_TouchNGo()
        {
            var sourceID = RetrieveTouchNGoSourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
            Console.WriteLine($"source platform is {source.PlatformType.ToString()}");
        }

        protected string RetrieveTouchNGoSourceId()
        {
            return RetrieveSourceTouchNGo().Result.Id;
        }

        #endregion

        #region OCBC PAO
        public async Task Create__Create_OCBC_PAO()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "sgd",
                Type = OffsiteTypes.MobileBankingOCBCPAO,
                PlatformType = PlatformTypes.iOS,
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_OCBC_PAO()
        {
            var sourceID = RetrieveOCBCPAOSourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
        }

        protected string RetrieveOCBCPAOSourceId()
        {
            return RetrieveSourceOCBCPAO().Result.Id;
        }
        #endregion

        #region Mobile Banking SCB
        public async Task Create__Create_Mobile_Banking_SCB()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Type = OffsiteTypes.MobileBankingSCB,
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_Mobile_Banking_SCB()
        {
            var sourceID = RetrieveMobileBankingSCBSourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
        }

        protected string RetrieveMobileBankingSCBSourceId()
        {
            return RetrieveSourceMobileBankingSCB().Result.Id;
        }
        #endregion

        #endregion

        #endregion
        #region PromptPay
        public async Task Create__Create_PromptPay()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Type = OffsiteTypes.PromptPay,
                PlatformType = PlatformTypes.Web,
                Email = "example@omise.co",
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_PromptPay()
        {
            var sourceID = RetrievePromptPaySourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
            Console.WriteLine($"source platform is {source.PlatformType.ToString()}");
        }

        protected string RetrievePromptPaySourceId()
        {
            return RetrieveSourcePromptPay().Result.Id;
        }

        #endregion

        #region ShopeePay
        public async Task Create__Create_ShopeePay()
        {
            var source = await Client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Type = OffsiteTypes.ShopeePay,
            });

            Console.WriteLine($"created source: {source.Id}");
        }

        public async Task Retrieve__Retrieve_ShopeePay()
        {
            var sourceID = RetrieveShopeePaySourceId();
            var source = await Client.Sources.Get(sourceID);
            Console.WriteLine($"source flow is {source.Flow.ToString()}");
        }

        protected string RetrieveShopeePaySourceId()
        {
            return RetrieveSourceShopeePay().Result.Id;
        }
        #endregion
    }
}
