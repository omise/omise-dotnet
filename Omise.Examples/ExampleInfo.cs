using System;
using dotenv.net;
namespace Omise.Examples
{
    public class ExampleInfo
    {
        static ExampleInfo()
        {
            DotEnv.Load();
        }
        public static string OMISE_PKEY => Environment.GetEnvironmentVariable("OMISE_PKEY");
        public static string OMISE_SKEY => Environment.GetEnvironmentVariable("OMISE_SKEY");

        public static string CUST_ID => Environment.GetEnvironmentVariable("CUST_ID");
        public static string CARD_ID => Environment.GetEnvironmentVariable("CARD_ID");

        public static string CUST_ID_2 => Environment.GetEnvironmentVariable("CUST_ID_2");
        public static string CARD_ID_2 => Environment.GetEnvironmentVariable("CARD_ID_2");

        public static string CUST_ID_3 => Environment.GetEnvironmentVariable("CUST_ID_3");

        public static string CHARGE_ID => Environment.GetEnvironmentVariable("CHARGE_ID");
        public static string REFUND_ID => Environment.GetEnvironmentVariable("REFUND_ID");
        public static string DISPUTE_ID => Environment.GetEnvironmentVariable("DISPUTE_ID");

        public static string TRANSACTION_ID => Environment.GetEnvironmentVariable("TRANSACTION_ID");

        public static string EVENT_ID => Environment.GetEnvironmentVariable("EVENT_ID");

        public static string LINK_ID => Environment.GetEnvironmentVariable("LINK_ID");

        public static string SCHEDULE_ID => Environment.GetEnvironmentVariable("SCHEDULE_ID");
        public static string OCCURRENCE_ID => Environment.GetEnvironmentVariable("OCCURRENCE_ID");

        public static string RECIPIENT_ID => Environment.GetEnvironmentVariable("RECIPIENT_ID");

        public static string TRANSFER_ID => Environment.GetEnvironmentVariable("TRANSFER_ID");

        public static string CHARGE_ID_WA => Environment.GetEnvironmentVariable("CHARGE_ID_WA");
    }
}