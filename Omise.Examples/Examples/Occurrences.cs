using Omise.Models;
using System;
using System.Threading.Tasks;

namespace Omise.Examples.Examples
{
    public class Occurrences : Example
    {
        public async Task List__List()
        {
            var scheduleId = "schd_test_58fiiv0w9m9tl9xnd55";
            var occurrences = await Client
                .Schedule(scheduleId)
                .Occurrences
                .GetList(order: Ordering.ReverseChronological);

            Console.WriteLine($"occurrences so far: {occurrences.Total}");
        }

        public async Task Retrieve__Retrieve()
        {
            var occurrenceId = "occu_test_58965eudn25i1gpip0w";
            var occurrence = await Client.Occurrences.Get(occurrenceId);
            Console.WriteLine($"this occurrence is on: {occurrence.ScheduleDate}");
        }
    }
}
