using System.Collections.Generic;

namespace Omise.Models
{
    public class CreateRefundRequest : Request
    {
        public long Amount { get; set; }
        public bool Void { get; set; }
        public IDictionary<string, object> Metadata { get; set; }
    }
}