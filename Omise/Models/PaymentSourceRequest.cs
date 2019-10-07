using System;

namespace Omise.Models
{
    public class CreatePaymentSourceRequest : Request
    {
        public SourceType Type { get; set; }
        public FlowTypes Flow { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public string Barcode { get; set; }
    }
}
