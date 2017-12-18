using Omise.Models;
using System.Threading.Tasks;
using System;

namespace Omise.Examples
{
    public class Charge_Schedules : Example
    {
        public async Task List__List()
        {
            var schedules = await Client
                .Charges
                .Schedules
                .GetList(order: Ordering.ReverseChronological);

            Console.WriteLine($"total charge schedules: {schedules.Total}");
        }

        public async Task Customer_List__List()
        {
            var customerId = TestInfo.CUST_ID_3;
            var schedules = await Client
                .Customer(customerId)
                .Schedules
                .GetList(order: Ordering.ReverseChronological);

            Console.WriteLine($"total schedule for customer: {schedules.Total}");
        }

        public async Task Create__Create_Daily()
        {
            var schedule = await Client.Schedules.Create(new CreateScheduleRequest
            {
                Every = 2,
                Period = SchedulePeriod.Day,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                On = new ScheduleOnRequest
                {
                    Weekdays = new[] { Weekdays.Monday }
                },
                Charge = new ChargeScheduling
                {
                    Amount = 2000,
                    Currency = "thb",
                    Customer = TestInfo.CUST_ID_3,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create__Create_Weekly()
        {
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
                Charge = new ChargeScheduling
                {
                    Amount = 2000,
                    Currency = "thb",
                    Customer = TestInfo.CUST_ID_3,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create__Create_Monthly()
        {
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
                Charge = new ChargeScheduling
                {
                    Amount = 2000,
                    Currency = "thb",
                    Customer = TestInfo.CUST_ID_3,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create__Create_Monthly_By_Week()
        {
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
                Charge = new ChargeScheduling
                {
                    Amount = 2000,
                    Currency = "thb",
                    Customer = TestInfo.CUST_ID_3,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Destroy__Destroy()
        {
            var schedule = RetrieveSchedule();
            schedule = await Client.Schedules.Destroy(schedule.Id);
            Console.WriteLine($"destroyed schedule: {schedule.Id}");
        }

        protected Schedule RetrieveSchedule()
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
                Charge = new ChargeScheduling
                {
                    Amount = 2000,
                    Currency = "thb",
                    Customer = TestInfo.CUST_ID_3,
                }
            }).Result;
        }
    }
}
