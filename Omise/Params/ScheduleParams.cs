using Newtonsoft.Json;
using System;

namespace Omise.Models
{
    public class CreateScheduleParams : Params
    {
        [JsonProperty("charge")]
        public ChargeScheduling Charge { get; set; }
        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }
        [JsonProperty("every")]
        public long Every { get; set; }
        [JsonProperty("on")]
        public ScheduleOnParams On { get; set; }
        [JsonProperty("period")]
        public SchedulePeriod Period { get; set; }
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }
        [JsonProperty("transfer")]
        public TransferScheduling Transfer { get; set; }
    }
}