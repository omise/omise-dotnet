using Omise.Models;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Omise.Examples
{
    public class Events : Example
    {
        public async Task List__List()
        {
            var events = await Client.Events.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"total events: {events.Total}");
        }

        public async Task Retrieve__Retrieve()
        {
            var ev = await Client.Events.Get(TestInfo.EVENT_ID);
            Console.WriteLine($"event action: {ev.Key} {ev.Data.Id}");
        }
    }
}
