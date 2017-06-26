using System;
using Omise.Models;
using System.Threading.Tasks;

namespace Omise.Examples.Examples
{
    public class Schedules : Example
    {
        public async Task List_List()
        {
            var schedules = await Client.Schedules.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"total schedules: {schedules.Total}");
        }

        public async Task Retrieve_Retrieve()
        {
            var scheduleId = "schd_test_58fmj4fpu2zpp2m8s8c";
            var schedule = await Client.Schedules.Get(scheduleId);
            Console.WriteLine($"charges made on schedule: {schedule.Occurrences.Total}");
        }

        public async Task Destroy_Destroy()
        {
            var schedule = RetrieveSchedule();
            schedule = await Client.Schedules.Destroy(schedule.Id);
            Console.WriteLine($"disabled schedule: {schedule.Id} ({schedule.Deleted})");
        }

        protected Schedule RetrieveSchedule()
        {
            return Client.Schedules.Create(new CreateScheduleRequest
            {
                Every = 12,
                Period = SchedulePeriod.Month,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                On = new ScheduleOnRequest
                {
                    DaysOfMonth = new[] { 1 }
                },
                Charge = new ChargeScheduling
                {
                    Amount = 2000,
                    Currency = "thb",
                    Customer = "cust_test_566l67k7etfyl0k49mi",
                }
            }).Result;
        }
    }
}
