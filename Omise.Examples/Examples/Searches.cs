using Omise.Models;
using System.Threading.Tasks;
using System;

namespace Omise.Examples.Examples
{
    public class Searches : Example
    {
        public async Task Search__Search()
        {
            var charges = await Client.Charges.Search(
                query: "TSUNAMI",
                order: Ordering.ReverseChronological
            );

            Console.WriteLine($"total tsunami charges: {charges.Total}");
        }
    }
}
