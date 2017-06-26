using Omise.Models;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Omise.Examples.Examples
{
    public class Events : Example
    {
        public async Task List_List()
        {
            var events = await Client.Events.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"total events: {events.Total}");
        }

        public async Task Retrieve_Retrieve()
        {
            var ev = await Client.Events.Get("evnt_test_58fffxu2gn498pb03pd");
            Console.WriteLine($"event action: {ev.Key} {ev.Data.Id}");
        }
    }
}
