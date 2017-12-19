using Omise.Models;
using System.Threading.Tasks;
using System;
using System.Diagnostics.Contracts;
using System.Diagnostics;

namespace Omise.Examples
{
    public class Recipients : Example
    {
        public async Task List__List()
        {
            var recipients = await Client.Recipients.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"total recipients: {recipients.Total}");
        }

        public async Task Create__Create()
        {
            var recipient = await Client.Recipients.Create(new CreateRecipientRequest
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Description = "John Doe (user: 30)",
                Type = RecipientType.Individual,
                BankAccount = new BankAccountRequest
                {
                    Brand = "kbank",
                    Number = "7777777777",
                    Name = "Dohn Joe",
                },
            });

            Console.WriteLine($"created recipient: {recipient.Id}");
        }

        public async Task Retrieve__Retrieve()
        {
            var recipientId = ExampleInfo.RECIPIENT_ID; // "recp_test_57po4c5obpi7rrxhtyl";
            var recipient = await Client.Recipients.Get(recipientId);
            Console.WriteLine($"recipient account last digits: {recipient.BankAccount.LastDigits}");
        }

        public async Task Update__Update()
        {
            var recipientId = ExampleInfo.RECIPIENT_ID; // "recp_test_57po4c5obpi7rrxhtyl";
            var recipient = await Client.Recipients.Update(recipientId, new UpdateRecipientRequest
            {
                Name = "Dohn Joe",
                Email = "dohn.joe@example.com",
            });

            Console.WriteLine($"updated recipient: {recipient.Id}");
        }

        public async Task Destroy__Destroy()
        {
            var recipient = RetrieveRecipient();
            recipient = await Client.Recipients.Destroy(recipient.Id);
            Console.WriteLine($"destroyed recipient: {recipient.Id} ({recipient.Deleted})");
        }

        protected Recipient RetrieveRecipient()
        {
            return Client.Recipients.Create(new CreateRecipientRequest
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Description = "John Doe (user: 30)",
                Type = RecipientType.Individual,
                BankAccount = new BankAccountRequest
                {
                    Brand = "kbank",
                    Number = "7777777777",
                    Name = "Dohn Joe",
                },
            }).Result;
        }
    }
}
