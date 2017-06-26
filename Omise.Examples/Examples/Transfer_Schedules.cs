using Omise.Models;
using System.Threading.Tasks;
using System;

namespace Omise.Examples
{
    public class Transfer_Schedules : Example
    {
        public async Task Create_Create_Daily()
        {
            var recipientId = "recp_test_58fkcajowtvy3pax0ak";
            var schedule = await Client.Schedules.Create(new CreateScheduleRequest
            {
                Every = 2,
                Period = SchedulePeriod.Day,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                Transfer = new TransferScheduling
                {
                    Amount = 200000,
                    Recipient = recipientId,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create_Create_Weekly()
        {
            var recipientId = "recp_test_58fkcajowtvy3pax0ak";
            var schedule = await Client.Schedules.Create(new CreateScheduleRequest
            {
                Every = 1,
                Period = SchedulePeriod.Week,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                On = new ScheduleOnRequest
                {
                    Weekdays = new[] { Weekdays.Monday, Weekdays.Friday }
                },
                Transfer = new TransferScheduling
                {
                    PercentageOfBalance = 75.0f,
                    Recipient = recipientId,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create_Create_Monthly()
        {
            var recipientId = "recp_test_58fkcajowtvy3pax0ak";
            var schedule = await Client.Schedules.Create(new CreateScheduleRequest
            {
                Every = 3,
                Period = SchedulePeriod.Month,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                On = new ScheduleOnRequest
                {
                    DaysOfMonth = new[] { 1, 10, 15 }
                },
                Transfer = new TransferScheduling
                {
                    Recipient = recipientId,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create_Create_Monthly_By_Week()
        {
            var recipientId = "recp_test_58fkcajowtvy3pax0ak";
            var schedule = await Client.Schedules.Create(new CreateScheduleRequest
            {
                Every = 1,
                Period = SchedulePeriod.Month,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                On = new ScheduleOnRequest
                {
                    WeekdayOfMonth = "2nd_monday"
                },
                Transfer = new TransferScheduling
                {
                    Recipient = recipientId,
                },
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }
    }
}
