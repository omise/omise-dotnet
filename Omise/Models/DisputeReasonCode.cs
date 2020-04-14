using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum DisputeReasonCode
    {
        [EnumMember(Value = "cancelled_recurring_transaction")]
        CancelledRecurringTransaction,
        [EnumMember(Value = "credit_not_processed")]
        CreditNotProcessed,
        [EnumMember(Value = "duplicate_processing")]
        DuplicateProcessing,
        [EnumMember(Value = "expired_card")]
        ExpiredCard,
        [EnumMember(Value = "goods_or_services_not_provided")]
        GoodsOrServicesNotProvided,
        [EnumMember(Value = "incorrect_currency")]
        IncorrectCurrency,
        [EnumMember(Value = "incorrect_transaction_amount")]
        IncorrectTransactionAmount,
        [EnumMember(Value = "late_presentment")]
        LatePresentment,
        [EnumMember(Value = "non_matching_account_number")]
        NonMatchingAccountNumber,
        [EnumMember(Value = "not_as_described_or_defective_merchandise")]
        NotAsDescribedOrDefectiveMerchandise,
        [EnumMember(Value = "not_available")]
        NotAvailable,
        [EnumMember(Value = "not_recorded")]
        NotRecorded,
        [EnumMember(Value = "other")]
        Other,
        [EnumMember(Value = "paid_by_other_means")]
        PaidByOtherMeans,
        [EnumMember(Value = "transaction_not_recognised")]
        TransactionNotRecognised,
        [EnumMember(Value = "unauthorized_charge")]
        UnauthorizedCharge
    }
}
