using Omise.Models;
using System.Threading.Tasks;
using System;

namespace Omise.Examples
{
    public class Transfer_Schedules : Example
    {
        public async Task List__List()
        {
            var schedules = await Client
                .Transfers
                .Schedules
                .GetList(order: Ordering.ReverseChronological);

            Console.WriteLine($"total transfer schedules: {schedules.Total}");
        }

        public async Task List__Recipient_List()
        {
            var recipientId = "recp_test_58fkcajowtvy3pax0ak";
            var schedules = await Client
                .Recipient(recipientId)
                .Schedules
                .GetList(order: Ordering.ReverseChronological);

            Console.WriteLine($"transfer schedule for recipients: {schedules.Total}");
        }

        public async Task Create__Create_Daily_Fixed_Amount()
        {
            var recipient = RetrieveRecipient();
            var schedule = await Client.Schedules.Create(new CreateScheduleRequest
            {
                Every = 2,
                Period = SchedulePeriod.Day,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                Transfer = new TransferScheduling
                {
                    Amount = 200000,
                    Recipient = recipient.Id,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create__Create_Weekly_Percentage()
        {
            var recipient = RetrieveRecipient();
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
                    Recipient = recipient.Id,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create__Create_Monthly_Whole_Balance()
        {
            var recipient = RetrieveRecipient();
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
                    Recipient = recipient.Id,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create__Create_Monthly_By_Week_Whole_Balance()
        {
            var recipient = RetrieveRecipient();
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
                    Recipient = recipient.Id,
                },
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Destroy__Destroy()
        {
            var schedule = RetrieveTransferSchedule();
            schedule = await Client.Schedules.Destroy(schedule.Id);
            Console.WriteLine($"destroyed schedule: {schedule.Id} ({schedule.Deleted})");
        }

        protected Schedule RetrieveTransferSchedule()
        {
            return Client.Schedules.Create(new CreateScheduleRequest
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
                    Recipient = RetrieveRecipient().Id,
                },
            }).Result;
        }

        protected Recipient RetrieveRecipient()
        {
            return Client.Recipients.Create(new CreateRecipientRequest
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Description = "John Doe (user: 30)",
                Type = RecipientType.Individual,
                BankAccount = new BankAccountRequest
                {
                    Brand = "kbank",
                    Number = "7777777777",
                    Name = "Dohn Joe",
                },
            }).Result;
        }
    }
}
