using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum OffsiteTypes
    {
        [EnumMember(Value = null)]
        None,
        [EnumMember(Value = "internet_banking_scb")]
        InternetBankingSCB,
        [EnumMember(Value = "internet_banking_bbl")]
        InternetBankingBBL,
        [EnumMember(Value = "internet_banking_ktb")]
        InternetBankingKTB,
        [EnumMember(Value = "internet_banking_bay")]
        InternetBankingBAY,
        [EnumMember(Value = "alipay")]
        AlipayOnline,
        [EnumMember(Value = "installment_bay")]
        InstallmentBAY,
        [EnumMember(Value = "installment_kbank")]
        InstallmentKBank,
        [EnumMember(Value = "bill_payment_tesco_lotus")]
        BillPaymentTescoLotus, 
        [EnumMember(Value = "wallet_alipay")]
        WalletAlipay
    }
}
