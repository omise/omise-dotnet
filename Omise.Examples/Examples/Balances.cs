using System;
using System.Threading.Tasks;

namespace Omise.Examples
{
    public class Balances : Example
    {
        public async Task Retrieve__Retrieve()
        {
            var balance = await Client.Balance.Get();
            Console.WriteLine($"available balance: {balance.Available}");
            Console.WriteLine($"total balance: {balance.Total}");
        }
    }
}