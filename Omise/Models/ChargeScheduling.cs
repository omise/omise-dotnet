using System;

namespace Omise.Models
{
    public class ChargeScheduling
    {
        public long Amount { get; set; }
        public string Currency { get; set; }
        public string Customer { get; set; }
        public string Card { get; set; }
    }
}
