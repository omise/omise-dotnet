using Newtonsoft.Json;
using System;

namespace Omise.Models
{
    public partial class Occurrence : ModelBase
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("processed_at")]
        public DateTime ProcessedAt { get; set; }
        [JsonProperty("result")]
        public string Result { get; set; }
        [JsonProperty("retry_on")]
        public DateTime RetryDate { get; set; }
        [JsonProperty("schedule")]
        public string Schedule { get; set; }
        [JsonProperty("scheduled_on")]
        public DateTime ScheduleDate { get; set; }
        [JsonProperty("status")]
        public OccurrenceStatus Status { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Occurrence;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Message, another.Message) &&
                object.Equals(this.ProcessedAt, another.ProcessedAt) &&
                object.Equals(this.Result, another.Result) &&
                object.Equals(this.RetryDate, another.RetryDate) &&
                object.Equals(this.Schedule, another.Schedule) &&
                object.Equals(this.ScheduleDate, another.ScheduleDate) &&
                object.Equals(this.Status, another.Status) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Message != default(string)) {
                    hash = hash * 23 + Message.GetHashCode();
                }
                if (ProcessedAt != default(DateTime)) {
                    hash = hash * 23 + ProcessedAt.GetHashCode();
                }
                if (Result != default(string)) {
                    hash = hash * 23 + Result.GetHashCode();
                }
                if (RetryDate != default(DateTime)) {
                    hash = hash * 23 + RetryDate.GetHashCode();
                }
                if (Schedule != default(string)) {
                    hash = hash * 23 + Schedule.GetHashCode();
                }
                if (ScheduleDate != default(DateTime)) {
                    hash = hash * 23 + ScheduleDate.GetHashCode();
                }
                if (Status != default(OccurrenceStatus)) {
                    hash = hash * 23 + Status.GetHashCode();
                }

                return hash;
            }
        }
    }
}