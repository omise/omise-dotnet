using System.Runtime.Serialization;

namespace Omise.Models
{
    public enum Offsite
    {
        [EnumMember(Value = "alipay")]
        Alipay,
        [EnumMember(Value = "internet_banking_bay")]
        InternetBankingBAY,
        [EnumMember(Value = "internet_banking_bbl")]
        InternetBankingBBL,
        [EnumMember(Value = "internet_banking_ktb")]
        InternetBankingKTB,
        [EnumMember(Value = "internet_banking_scb")]
        InternetBankingSCB
    }
}
