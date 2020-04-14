﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Omise.Resources;
using Omise.Models;
using System.Threading.Tasks;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class ScheduleResourceTest : ResourceTest<ScheduleResource>
    {
        const string ScheduleId = "schd_test_57weuktrvln3bhtfolm";
        const string CustomerId = "cust_test_57weukrimynz11hwz77";

        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/schedules");
        }

        [Test]
        public async Task TestGet()
        {
            await Resource.Get(ScheduleId);
            AssertRequest("GET", $"https://api.omise.co/schedules/{ScheduleId}");
        }

        [Test]
        public async Task TestCreate()
        {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://api.omise.co/schedules");
        }

        [Test]
        public async Task TestDestroy()
        {
            await Resource.Destroy(ScheduleId);
            AssertRequest("DELETE", $"https://api.omise.co/schedules/{ScheduleId}");
        }

        [Test]
        public void CreateScheduleRequest()
        {
            var a = BuildCreateRequest();
            var b = new Dictionary<string, object>
                {
                    { "every", 1 },
                    { "period", "week" },
                    { "on", new Dictionary<string, object>
                        {
                            {"weekdays", new List<string>{"friday"}},
                        }
                    },
                    { "end_date", "2099-02-01T19:54:00" },
                    { "charge", new Dictionary<string, object>
                        {
                            { "amount", 3333 },
                            { "currency", "thb" },
                            { "customer", "cust_test_57weukrimynz11hwz77" },
                            { "default_card", false },
                        }
                    }
                };

            AssertSerializedRequest(a, b);
        }

        protected CreateScheduleParams BuildCreateRequest()
        {
            return new CreateScheduleParams
            {
                Every = 1,
                Period = SchedulePeriod.Week,
                On = new ScheduleOnRequest
                {
                    Weekdays = new Weekdays[] { Weekdays.Friday },
                },
                EndDate = new DateTime(2099, 2, 1, 19, 54, 00),
                Charge = new ChargeScheduling
                {
                    Amount = 3333,
                    Currency = "thb",
                    Customer = CustomerId,
                }
            };
        }

        protected override ScheduleResource BuildResource(IRequester requester)
        {
            return new ScheduleResource(requester);
        }
    }
}
