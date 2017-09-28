using System;
using Omise.Models;
using System.Threading.Tasks;

namespace Omise.Examples.Examples
{
    public class Refunds : Example
    {
        public async Task List__List()
        {
            var refunds = await Client
                .Refunds
                .GetList(order: Ordering.ReverseChronological);

            Console.WriteLine($"refunds so far: {refunds.Total}");
        }

        public async Task Charge_List__Charge_List()
        {
            var chargeId = "chrg_test_58fkc7mrh99fnymu214";
            var refunds = await Client
                .Charge(chargeId)
                .Refunds
                .GetList(order: Ordering.ReverseChronological);

            Console.WriteLine($"refunds for this charge: {refunds.Total}");
        }

        public async Task Create__Create()
        {
            var charge = RetrieveCharge();
            var refund = await Client.Charge(charge.Id).Refunds.Create(new CreateRefundRequest
            {
                Amount = charge.Amount,
            });

            Console.WriteLine($"created refund: {refund.Id}");
        }

        public async Task Retrieve__Retrieve()
        {
            var chargeId = "chrg_test_58fkc7mrh99fnymu214";
            var refundId = "rfnd_test_58fkcxsbyxodfei74kt";
            var refund = await Client.Charge(chargeId).Refunds.Get(refundId);
            Console.WriteLine($"refunded: {refund.Amount}");
        }

        protected Charge RetrieveCharge()
        {
            var token = RetrieveToken().Result;
            return Client.Charges.Create(new CreateChargeRequest
            {
                Amount = 2000,
                Currency = "thb",
                Card = token.Id,
            }).Result;
        }
    }
}
