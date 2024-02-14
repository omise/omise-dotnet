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
        [EnumMember(Value = "alipay_cn")]
        AlipayCN,
        [EnumMember(Value = "alipay_hk")]
        AlipayHK,
        [EnumMember(Value = "dana")]
        DANA,
        [EnumMember(Value = "gcash")]
        GCash,
        [EnumMember(Value = "kakaopay")]
        KakaoPay,
        [EnumMember(Value = "touch_n_go")]
        TouchNGo,
        [EnumMember(Value = "fpx")]
        Fpx,
        [EnumMember(Value = "installment_bay")]
        InstallmentBAY,
        [EnumMember(Value = "installment_kbank")]
        InstallmentKBank,
        [EnumMember(Value = "installment_scb")]
        InstallmentSCB,
        [EnumMember(Value = "installment_citi")]
        InstallmentCiti,
        [EnumMember(Value = "bill_payment_tesco_lotus")]
        BillPaymentTescoLotus,
        [EnumMember(Value = "barcode_alipay")]
        BarcodeAlipay,
        [EnumMember(Value = "mobile_banking_ocbc_pao")]
        MobileBankingOCBCPAO,
        [EnumMember(Value = "rabbit_linepay")]
        RabbitLinepay,
        [EnumMember(Value = "wechat_pay")]
        WeChatPay,
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
