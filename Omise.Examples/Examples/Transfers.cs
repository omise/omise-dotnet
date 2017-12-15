using Omise.Models;
using System.Threading.Tasks;
using System;

namespace Omise.Examples
{
    public class Transfers : Example
    {
        public async Task List__List()
        {
            var transfers = await Client.Transfers.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"total transfers: {transfers.Total}");
        }

        public async Task Create__Create()
        {
            var transfer = await Client.Transfers.Create(new CreateTransferRequest
            {
                Amount = 200000,
                FailFast = true,
            });

            Console.WriteLine($"created transfer: {transfer.Id}");
        }

        public async Task Create__Create_With_Recipient()
        {
            var recipientId = "recp_test_560ph01r04muv1a28ze";
            var transfer = await Client.Transfers.Create(new CreateTransferRequest
            {
                Amount = 200000,
                FailFast = true,
                Recipient = recipientId,
            });

            Console.WriteLine($"created transfer: {transfer.Id}");
        }

        public async Task Retrieve__Retrieve()
        {
            var transferId = "trsf_test_560ph0660cgiag1xjeh";
            var transfer = await Client.Transfers.Get(transferId);
            Console.WriteLine($"transfer amount: {transfer.Amount}");
        }

        public async Task Update__Update()
        {
            var transferId = "trsf_test_57po4c8r5hr41flvcw7";
            var transfer = await Client.Transfers.Update(transferId, new UpdateTransferRequest
            {
                Amount = 733137
            });

            Console.WriteLine($"updated transfer: {transfer.Id}");
        }

        public async Task Destroy__Destroy()
        {
            var transfer = RetrieveTransfer();
            transfer = await Client.Transfers.Destroy(transfer.Id);
            Console.WriteLine($"destroyed transfer: {transfer.Id} ({transfer.Deleted})");
        }

        protected Transfer RetrieveTransfer()
        {
            return Client.Transfers.Create(new CreateTransferRequest
            {
                Amount = 200000,
                FailFast = true,
                Recipient = "recp_test_560ph01r04muv1a28ze",
            }).Result;
        }
    }
}
