using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise.Models
{
    public partial class ScheduleOn : ModelBase
    {
        [JsonProperty("days_of_month")]
        public List<long> DaysOfMonth { get; set; }
        [JsonProperty("weekday_of_month")]
        public string WeekdayOfMonth { get; set; }
        [JsonProperty("weekdays")]
        public List<Weekdays> Weekdays { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as ScheduleOn;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.DaysOfMonth, another.DaysOfMonth) &&
                object.Equals(this.WeekdayOfMonth, another.WeekdayOfMonth) &&
                object.Equals(this.Weekdays, another.Weekdays) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (DaysOfMonth != default(List<long>)) {
                    hash = hash * 23 + DaysOfMonth.GetHashCode();
                }
                if (WeekdayOfMonth != default(string)) {
                    hash = hash * 23 + WeekdayOfMonth.GetHashCode();
                }
                if (Weekdays != default(List<Weekdays>)) {
                    hash = hash * 23 + Weekdays.GetHashCode();
                }

                return hash;
            }
        }
    }
}