using System.Threading.Tasks;

namespace Omise.Example {
    public class AccountBalanceExample : Example {
        public override async Task Run() {
            var account = await Client.Account.Get();
            var balance = await Client.Balance.Get();

            Print("account's email:   {0}", account.Email);
            Print("available balance: {0}", balance.Available);
        }
    }
}