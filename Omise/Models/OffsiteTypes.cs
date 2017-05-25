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
        InternetBankingBAY
    }
}
