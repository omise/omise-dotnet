using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum RecurringReason
    {
        [EnumMember(Value = "blank")]
        Blank,
        [EnumMember(Value = "unscheduled")]
        Unscheduled,
        [EnumMember(Value = "standing_order")]
        StandingOrder,
        [EnumMember(Value = "subscription")]
        Subscription,
        [EnumMember(Value = "installment")]
        Installment,
        [EnumMember(Value = "partial_shipment")]
        PartialShipment,
        [EnumMember(Value = "delayed_charge")]
        DelayedCharge,
        [EnumMember(Value = "no_show")]
        NoShow,
        [EnumMember(Value = "resubmission")]
        Resubmission
    }
}