using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Omise.Models
{
    /// <summary>
    /// Schedule object
    ///
    /// <a href="https://www.omise.co/schedules-api">Schedule API</a>
    /// </summary>
    public partial class Schedule : ModelBase
    {
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("charge")]
        public ChargeScheduling Charge { get; set; }
        [JsonProperty("end_on")]
        public DateTime EndOn { get; set; }
        [JsonProperty("ended_at")]
        public DateTime EndedAt { get; set; }
        [JsonProperty("every")]
        public long Every { get; set; }
        [JsonProperty("in_words")]
        public string InWords { get; set; }
        [JsonProperty("next_occurrences_on")]
        public List<string> NextOccurrencesOn { get; set; }
        [JsonProperty("occurrences")]
        public ScopedList<Occurrence> Occurrences { get; set; }
        [JsonProperty("on")]
        public ScheduleOnRequest On { get; set; }
        [JsonProperty("period")]
        public SchedulePeriod Period { get; set; }
        [JsonProperty("start_on")]
        public DateTime StartOn { get; set; }
        [JsonProperty("status")]
        public ScheduleStatus Status { get; set; }
        [JsonProperty("transfer")]
        public TransferScheduling Transfer { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Schedule;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Active, another.Active) &&
                object.Equals(this.Charge, another.Charge) &&
                object.Equals(this.EndOn, another.EndOn) &&
                object.Equals(this.EndedAt, another.EndedAt) &&
                object.Equals(this.Every, another.Every) &&
                object.Equals(this.InWords, another.InWords) &&
                object.Equals(this.NextOccurrencesOn, another.NextOccurrencesOn) &&
                object.Equals(this.Occurrences, another.Occurrences) &&
                object.Equals(this.On, another.On) &&
                object.Equals(this.Period, another.Period) &&
                object.Equals(this.StartOn, another.StartOn) &&
                object.Equals(this.Status, another.Status) &&
                object.Equals(this.Transfer, another.Transfer) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                if (Active != default(bool)) {
                    hash = hash * 23 + Active.GetHashCode();
                }
                if (Charge != default(ChargeScheduling)) {
                    hash = hash * 23 + Charge.GetHashCode();
                }
                if (EndOn != default(DateTime)) {
                    hash = hash * 23 + EndOn.GetHashCode();
                }
                if (EndedAt != default(DateTime)) {
                    hash = hash * 23 + EndedAt.GetHashCode();
                }
                if (Every != default(long)) {
                    hash = hash * 23 + Every.GetHashCode();
                }
                if (InWords != default(string)) {
                    hash = hash * 23 + InWords.GetHashCode();
                }
                if (NextOccurrencesOn != default(List<string>)) {
                    hash = hash * 23 + NextOccurrencesOn.GetHashCode();
                }
                if (Occurrences != default(ScopedList<Occurrence>)) {
                    hash = hash * 23 + Occurrences.GetHashCode();
                }
                if (On != default(ScheduleOnRequest)) {
                    hash = hash * 23 + On.GetHashCode();
                }
                if (Period != default(SchedulePeriod)) {
                    hash = hash * 23 + Period.GetHashCode();
                }
                if (StartOn != default(DateTime)) {
                    hash = hash * 23 + StartOn.GetHashCode();
                }
                if (Status != default(ScheduleStatus)) {
                    hash = hash * 23 + Status.GetHashCode();
                }
                if (Transfer != default(TransferScheduling)) {
                    hash = hash * 23 + Transfer.GetHashCode();
                }

                return hash;
            }
        }
    }

    public class CreateScheduleParams : Request
    {
        [JsonProperty("charge")]
        public ChargeScheduling Charge { get; set; }
        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }
        [JsonProperty("every")]
        public long Every { get; set; }
        [JsonProperty("on")]
        public ScheduleOnRequest On { get; set; }
        [JsonProperty("period")]
        public SchedulePeriod Period { get; set; }
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }
        [JsonProperty("transfer")]
        public TransferScheduling Transfer { get; set; }
    }
}