using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum SourceType
    {
        [EnumMember(Value = "alipay")]
        Alipay,
        [EnumMember(Value = "barcode_alipay")]
        BarcodeAlipay,
        [EnumMember(Value = "bill_payment_tesco_lotus")]
        BillPaymentTescoLotus,
        [EnumMember(Value = "econtext")]
        Econtext,
        [EnumMember(Value = "installment_bay")]
        InstallmentBAY,
        [EnumMember(Value = "installment_bbl")]
        InstallmentBBL,
        [EnumMember(Value = "installment_first_choice")]
        InstallmentFirstChoice,
        [EnumMember(Value = "installment_kbank")]
        InstallmentKBANK,
        [EnumMember(Value = "installment_ktc")]
        InstallmentKTC,
        [EnumMember(Value = "internet_banking_bay")]
        InternetBankingBAY,
        [EnumMember(Value = "internet_banking_bbl")]
        InternetBankingBBL,
        [EnumMember(Value = "internet_banking_ktb")]
        InternetBankingKTB,
        [EnumMember(Value = "internet_banking_scb")]
        InternetBankingSCB,
        [EnumMember(Value = "paynow")]
        Paynow,
        [EnumMember(Value = "points_citi")]
        PointsCiti,
        [EnumMember(Value = "promptpay")]
        PromptPay,
        [EnumMember(Value = "truemoney")]
        TrueMoney
    }
}
