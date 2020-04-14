using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum ChargeFailureCode
    {
        [EnumMember(Value = "failed_fraud_check")]
        FailedFraudCheck,
        [EnumMember(Value = "failed_processing")]
        FailedProcessing,
        [EnumMember(Value = "insufficient_balance")]
        InsufficientBalance,
        [EnumMember(Value = "insufficient_fund")]
        InsufficientFund,
        [EnumMember(Value = "invalid_account_number")]
        InvalidAccountNumber,
        [EnumMember(Value = "invalid_security_code")]
        InvalidSecurityCode,
        [EnumMember(Value = "payment_cancelled")]
        PaymentCancelled,
        [EnumMember(Value = "payment_rejected")]
        PaymentRejected,
        [EnumMember(Value = "timeout")]
        Timeout
    }
}
