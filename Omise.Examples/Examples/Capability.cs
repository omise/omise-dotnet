using System;
using System.Threading.Tasks;

namespace Omise.Examples
{
    public class Capability : Example
    {
        public async Task Retrieve__Retrieve()
        {
            var capability = await Client.Capability.Get();
            Console.WriteLine($"Country: {capability.Country}");
        }
    }
}