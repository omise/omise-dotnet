using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Example {
    public class TransferMoneyExample : Example {
        public async override Task Run() {
            var transfer = await Client.Transfers.Create(new CreateTransferRequest {
                Amount = 1000000 // 10,000.00 THB
            });

            Print("created transfer: {0}", transfer.Id);
        }
    }
}