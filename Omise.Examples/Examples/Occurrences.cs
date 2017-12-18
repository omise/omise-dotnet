using Omise.Models;
using System;
using System.Threading.Tasks;

namespace Omise.Examples
{
    public class Occurrences : Example
    {
        public async Task List__List()
        {
            var scheduleId = TestInfo.SCHEDULE_ID;
            var occurrences = await Client
                .Schedule(scheduleId)
                .Occurrences
                .GetList(order: Ordering.ReverseChronological);

            Console.WriteLine($"occurrences so far: {occurrences.Total}");
        }

        public async Task Retrieve__Retrieve()
        {
            var occurrenceId = TestInfo.OCCURRENCE_ID;
            var occurrence = await Client.Occurrences.Get(occurrenceId);
            Console.WriteLine($"this occurrence is on: {occurrence.ScheduleDate}");
        }
    }
}
