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
                PhoneNumber = "0812345678"
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
    }
}
