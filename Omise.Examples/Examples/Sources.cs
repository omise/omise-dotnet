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
            var source = await Client.Sources.Create(new CreateSourceParams
            {
                Amount = 2000,
                Currency = "thb",
                Type = SourceType.InternetBankingBAY,
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
            var source = await Client.Sources.Create(new CreateSourceParams
            {
                Amount = 2000,
                Currency = "thb",
                Type = SourceType.BillPaymentTescoLotus,
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

    }
}
