using Omise.Models;
using System.Threading.Tasks;
using System;

namespace Omise.Examples
{
    public class Charge_Schedules : Example
    {
        public async Task List_List()
        {
            var schedules = await Client
                .Charges
                .Schedules
                .GetList(order: Ordering.ReverseChronological);

            Console.WriteLine($"total charge schedules: {schedules.Total}");
        }

        public async Task List_Customer_List()
        {
            var customerId = "cust_test_566l67k7etfyl0k49mi";
            var schedules = await Client
                .Customer(customerId)
                .Schedules
                .GetList(order: Ordering.ReverseChronological);

            Console.WriteLine($"total schedule for customer: {schedules.Total}");
        }

        public async Task Create_Create_Daily()
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
                    Customer = "cust_test_566l67k7etfyl0k49mi",
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create_Create_Weekly()
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
                    Customer = "cust_test_566l67k7etfyl0k49mi",
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create_Create_Monthly()
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
                    Customer = "cust_test_566l67k7etfyl0k49mi",
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create_Create_Monthly_By_Week()
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
                    Customer = "cust_test_566l67k7etfyl0k49mi",
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Destroy_Destroy()
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
                    Customer = "cust_test_566l67k7etfyl0k49mi",
                }
            }).Result;
        }
    }
}
