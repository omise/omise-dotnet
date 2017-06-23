using System.Threading.Tasks;
using System;
using Omise.Models;
using System.Linq;

namespace Omise.Examples
{
    public class Disputes : Example
    {
        public async Task List_List()
        {
            var resource = Client.Disputes;
            var disputes = await resource.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"total disputes: {disputes.Total}");
        }

        public async Task Open_Open()
        {
            var resource = Client.Disputes.OpenDisputes;
            var openDisputes = await resource.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"open disputes: {openDisputes.Total}");
        }

        public async Task Closed_Closed()
        {
            var resource = Client.Disputes.ClosedDisputes;
            var closedDisputes = await resource.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"closed disputes: {closedDisputes.Total}");
        }

        public async Task Pending_Pending()
        {
            var resource = Client.Disputes.PendingDisputes;
            var pendingDisputes = await resource.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"pending disputes: {pendingDisputes.Total}");
        }

        public async Task Retrieve_Retrieve()
        {
            var disputeId = "dspt_test_58edik07fvhh1i6i3ad";
            var dispute = await Client.Disputes.Get(disputeId);
            Console.WriteLine($"disputed amount: {dispute.Amount}");
        }

        public async Task Update_Update()
        {
            var dispute = RetrieveOpenDispute();
            dispute = await Client.Disputes.Update(dispute.Id, new UpdateDisputeRequest
            {
                Message = "Hello, World!"
            });

            Console.WriteLine($"updated dispute: {dispute.Id}");
        }

        protected Dispute RetrieveOpenDispute()
        {
            return Client.Disputes.OpenDisputes.GetList().Result.First();
        }
    }
}
