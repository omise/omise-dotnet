using Omise.Models;
using System.Threading.Tasks;
using System;

namespace Omise.Examples.Examples
{
    public class Forexes : Example
    {
        public async Task Retrieve__Retrieve()
        {
            var rate = await Client.Forex.Get("usd");
            Console.WriteLine($"conversion from USD to THB: {rate.Rate}");
        }
    }
}
