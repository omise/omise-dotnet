using System;
using System.Threading.Tasks;

namespace Omise.Examples
{
    public class Balances : Example
    {
        public async Task Retrieve_Retrieve()
        {
            var balance = await Client.Balance.Get();
            Console.WriteLine($"available balance: {balance.Available}");
            Console.WriteLine($"total balance: {balance.Total}");
        }
    }
}