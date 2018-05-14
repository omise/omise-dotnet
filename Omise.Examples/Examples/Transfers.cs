using Omise.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

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
            var recipientId = ExampleInfo.RECIPIENT_ID; // "recp_test_57po4c5obpi7rrxhtyl";
            var transfer = await Client.Transfers.Create(new CreateTransferRequest
            {
                Amount = 200000,
                FailFast = true,
                Recipient = recipientId,
            });

            Console.WriteLine($"created transfer: {transfer.Id}");
        }

        public async Task Create__Create_With_Metadata()
        {
            var transfer = await Client.Transfers.Create(new CreateTransferRequest
            {
                Amount = 200000,
                FailFast = true,
                Metadata = new Dictionary<string, object> { { "color", "red" } }
            });

            Console.WriteLine($"created transfer: {transfer.Id}");
        }

        public async Task Retrieve__Retrieve()
        {
            var transferId = ExampleInfo.TRANSFER_ID; // "trsf_test_560ph0660cgiag1xjeh";
            var transfer = await Client.Transfers.Get(transferId);
            Console.WriteLine($"transfer amount: {transfer.Amount}");
        }

        public async Task Update__Update()
        {
            var transferId = ExampleInfo.TRANSFER_ID; // "trsf_test_560ph0660cgiag1xjeh";
            var transfer = await Client.Transfers.Update(transferId, new UpdateTransferRequest
            {
                Amount = 733137
            });

            Console.WriteLine($"updated transfer: {transfer.Id}");
        }

        public async Task Update__Update_With_Metadata()
        {
            var transferId = ExampleInfo.TRANSFER_ID; // "trsf_test_560ph0660cgiag1xjeh";
            var transfer = await Client.Transfers.Update(transferId, new UpdateTransferRequest
            {
                Amount = 733137,
                Metadata = new Dictionary<string, object> { { "color", "red" } }
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
                Recipient = ExampleInfo.RECIPIENT_ID,
            }).Result;
        }
    }
}
