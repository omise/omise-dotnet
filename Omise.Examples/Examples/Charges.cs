using Omise.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace Omise.Examples
{
    public class Charges : Example
    {
        public async Task List_List()
        {
            var charges = await Client.Charges.GetList(order: Ordering.Chronological);
            Console.WriteLine($"total charges: {charges.Total}");
        }

        public async Task Retrieve_Retrieve()
        {
            var chargeId = "chrg_test_58e1ybdog1y8f5z97l8";
            var charge = await Client.Charges.Get(chargeId);
            Console.WriteLine($"charge amount: {charge.Amount}");
        }

        public async Task Create_Create_With_Token()
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

        public async Task Create_Create_With_Card()
        {
            var customerId = "cust_test_5665swqhhb3mioax1y7";
            var cardId = "card_test_5665swpkm6tv47htmuv";
            var charge = await Client.Charges.Create(new CreateChargeRequest
            {
                Amount = 2000,
                Currency = "thb",
                Customer = customerId,
                Card = cardId,
            });

            Console.WriteLine($"created charge: {charge.Id}");
        }

        public async Task Create_Create_With_Customer()
        {
            var customerId = "cust_test_5665swqhhb3mioax1y7";
            var charge = await Client.Charges.Create(new CreateChargeRequest
            {
                Amount = 2000,
                Currency = "thb",
                Customer = customerId,
            });

            Console.WriteLine($"created charge: {charge.Id}");
        }

        public async Task Capture_Capture()
        {
            var charge = RetrieveUncapturedCharge();
            charge = await Client.Charges.Capture(charge.Id);
            Console.WriteLine($"captured charge: ({charge.Paid}) {charge.Id}");
        }

        public async Task Reverse_Reverse()
        {
            var charge = RetrieveUncapturedCharge();
            charge = await Client.Charges.Reverse(charge.Id);
            Console.WriteLine($"reversed charge: ({charge.Reversed}) {charge.Id}");
        }

        public async Task Update_Update()
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
    }
}
