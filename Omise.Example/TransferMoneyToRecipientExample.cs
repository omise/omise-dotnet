using System;
using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Example {
    public class TransferMoneyToRecipientExample : Example {
        public async override Task Run() {
            var recipient = await Client.Recipients.Create(new CreateRecipientRequest
                {
                    Name = "Merchant X Smith",
                    Email = "john.doe@example.com",
                    Description = "merchant#456",
                    Type = RecipientType.Individual,
                    BankAccount = new BankAccountRequest
                    {
                        Brand = "bank",
                        Number = "7777-777-777",
                        Name = "Smith X.",
                    }
                });

            Print("created recipient: {0}", recipient.Id);

            var transfer = await Client.Transfers.Create(new CreateTransferRequest
                {
                    Amount = 99900, // 999.00 THB
                    Recipient = recipient.Id
                });

            Print("created transfer: {0}", transfer.Id);
        }
    }
}

