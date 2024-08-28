using System.Threading.Tasks;
using System;
using Omise.Models;
using System.Linq;
using System.Collections.Generic;

namespace Omise.Examples
{
    public class Disputes : Example
    {
        public async Task List__List()
        {
            var resource = Client.Disputes;
            var disputes = await resource.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"total disputes: {disputes.Total}");
        }

        public async Task Open__Open()
        {
            var resource = Client.Disputes.OpenDisputes;
            var openDisputes = await resource.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"open disputes: {openDisputes.Total}");
        }

        public async Task Closed__Closed()
        {
            var resource = Client.Disputes.ClosedDisputes;
            var closedDisputes = await resource.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"closed disputes: {closedDisputes.Total}");
        }

        public async Task Pending__Pending()
        {
            var resource = Client.Disputes.PendingDisputes;
            var pendingDisputes = await resource.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"pending disputes: {pendingDisputes.Total}");
        }

        public async Task Retrieve__Retrieve()
        {
            var disputeId = ExampleInfo.DISPUTE_ID; // "dspt_test_5abyfl6u9ri3ndo8gzv";
            var dispute = await Client.Disputes.Get(disputeId);
            Console.WriteLine($"disputed amount: {dispute.Amount}");
        }

        public async Task Update__Update()
        {
            var dispute = RetrieveOpenDispute();
            dispute = await Client.Disputes.Update(dispute.Id, new UpdateDisputeRequest
            {
                Message = "Hello, World!"
            });
            Console.WriteLine($"updated dispute: {dispute.Id}");
        }

        public async Task Update__UpdateWithMetadata()
        {
            var dispute = RetrieveOpenDispute();
            dispute = await Client.Disputes.Update(dispute.Id, new UpdateDisputeRequest
            {
                Message = "Hello, World!",
                Metadata = new Dictionary<string, object> { { "color", "red" } }
            });
            Console.WriteLine($"updated dispute: {dispute.Id}");
        }

        protected Dispute RetrieveOpenDispute()
        {
            return Client.Disputes.OpenDisputes.GetList().Result.First();
        }
    }
}
