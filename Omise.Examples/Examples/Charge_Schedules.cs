﻿using Omise.Models;
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
            var customerId = ExampleInfo.CUST_ID_3; // "cust_test_5aasqjmq7glo1c0pedk";
            var schedules = await Client
                .Customers
                .Customer(customerId)
                .Schedules
                .GetList(order: Ordering.ReverseChronological);

            Console.WriteLine($"total schedule for customer: {schedules.Total}");
        }

        public async Task Create__Create_Daily()
        {
            var schedule = await Client.Schedules.Create(new CreateScheduleParams
            {
                Every = 2,
                Period = SchedulePeriod.Day,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                On = new ScheduleOnParams
                {
                    Weekdays = new[] { Weekdays.Monday }
                },
                Charge = new ChargeScheduling
                {
                    Amount = 2000,
                    Currency = "thb",
                    Customer = ExampleInfo.CUST_ID_3,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create__Create_Weekly()
        {
            var schedule = await Client.Schedules.Create(new CreateScheduleParams
            {
                Every = 1,
                Period = SchedulePeriod.Week,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                On = new ScheduleOnParams
                {
                    Weekdays = new[] { Weekdays.Monday, Weekdays.Friday }
                },
                Charge = new ChargeScheduling
                {
                    Amount = 2000,
                    Currency = "thb",
                    Customer = ExampleInfo.CUST_ID_3,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create__Create_Monthly()
        {
            var schedule = await Client.Schedules.Create(new CreateScheduleParams
            {
                Every = 3,
                Period = SchedulePeriod.Month,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                On = new ScheduleOnParams
                {
                    DaysOfMonth = new[] { 1, 10, 15 }
                },
                Charge = new ChargeScheduling
                {
                    Amount = 2000,
                    Currency = "thb",
                    Customer = ExampleInfo.CUST_ID_3,
                }
            });

            Console.WriteLine($"created schedule: {schedule.Id}");
        }

        public async Task Create__Create_Monthly_By_Week()
        {
            var schedule = await Client.Schedules.Create(new CreateScheduleParams
            {
                Every = 1,
                Period = SchedulePeriod.Month,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                On = new ScheduleOnParams
                {
                    WeekdayOfMonth = "2nd_monday"
                },
                Charge = new ChargeScheduling
                {
                    Amount = 2000,
                    Currency = "thb",
                    Customer = ExampleInfo.CUST_ID_3,
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
            return Client.Schedules.Create(new CreateScheduleParams
            {
                Every = 1,
                Period = SchedulePeriod.Month,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(2),
                On = new ScheduleOnParams
                {
                    WeekdayOfMonth = "2nd_monday"
                },
                Charge = new ChargeScheduling
                {
                    Amount = 2000,
                    Currency = "thb",
                    Customer = ExampleInfo.CUST_ID_3,
                }
            }).Result;
        }
    }
}
