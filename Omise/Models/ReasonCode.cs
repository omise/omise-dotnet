using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum ReasonCode
    {
        [EnumMember(Value = "not_recorded")]
        NotRecorded,

        [EnumMember(Value = "not_available")]
        NotAvailable,

        [EnumMember(Value = "other")]
        Other,

        [EnumMember(Value = "incorrect_transaction_amount")]
        IncorrectTransactionAmount,

        [EnumMember(Value = "duplicate_processing")]
        DuplicateProcessing,

        [EnumMember(Value = "credit_not_processed")]
        CreditNotProcessed,

        [EnumMember(Value = "paid_by_other_means")]
        PaidByOtherMeans,

        [EnumMember(Value = "unauthorized_charge")]
        UnauthorizedCharge,

        [EnumMember(Value = "non_matching_account_number")]
        NonMatchingAccountNumber,

        [EnumMember(Value = "incorrect_currency")]
        IncorrectCurrency,

        [EnumMember(Value = "late_presentment")]
        LatePresentment,

        [EnumMember(Value = "cancelled_recurring_transaction")]
        CancelledRecurringTransaction,

        [EnumMember(Value = "not_as_described_or_defective_merchandise")]
        NotAsDescribedOrDefectiveMerchandise,

        [EnumMember(Value = "goods_or_services_not_provided")]
        GoodsOrServicesNotProvided,

        [EnumMember(Value = "incorrect_transaction_code")]
        IncorrectTransactionCode,

        [EnumMember(Value = "invalid_data")]
        InvalidData,

        [EnumMember(Value = "expired_card")]
        ExpiredCard,

        [EnumMember(Value = "transaction_not_recognised")]
        TransactionNotRecognized
    }
}
