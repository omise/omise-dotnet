using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace Omise.Models
{
    public class ScheduleOnRequest : Request
    {
        [JsonProperty("weekdays")]
        public Weekdays[] Weekdays { get; set; }
        [JsonProperty("days_of_month")]
        public int[] DaysOfMonth { get; set; }
        [JsonProperty("weekdays_of_month")]
        public String WeekdayOfMonth { get; set; }
    }

    public class CreateScheduleRequest : Request
    {
        public int Every { get; set; }
        public SchedulePeriod Period { get; set; }
        public ScheduleOnRequest On { get; set; }
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }
        [JsonProperty("end_date")]
        public DateTime? EndDate { get; set; }
        public ChargeScheduling Charge { get; set; }

        public CreateScheduleRequest()
        {
            On = new ScheduleOnRequest();
        }
    }
}
