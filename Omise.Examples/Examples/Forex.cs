using Omise.Models;
using System.Threading.Tasks;
using System;

namespace Omise.Examples.Examples
{
    public class Forex : Example
    {
        public async Task Retrieve_Retrieve()
        {
            var rate = await Client.Forex.Get("usd");
            Console.WriteLine($"conversion from USD to THB: {rate.Rate}");
        }
    }
}
