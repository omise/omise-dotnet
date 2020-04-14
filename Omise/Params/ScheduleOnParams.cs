using Newtonsoft.Json;

namespace Omise.Models
{
    public class ScheduleOnParams : Params
    {
        [JsonProperty("days_of_month")]
        public int[] DaysOfMonth { get; set; }
        [JsonProperty("weekday_of_month")]
        public string WeekdayOfMonth { get; set; }
        [JsonProperty("weekdays")]
        public Weekdays[] Weekdays { get; set; }
    }
}