using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Example {
    public class CreateChargeExample : Example {
        public async override Task Run() {
            var token = await CreateToken();
            var charge = await Client.Charges.Create(new CreateChargeRequest {
                Amount = int.Parse(Prompt("how much you want to charge")),
                Currency = "thb",
                Card = token.Id
            });

            Print($"created charge: {charge.Id}");
        }
    }
}