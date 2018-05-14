using System.Collections.Generic;

namespace Omise.Models
{
    public class UpdateDisputeRequest : Request
    {
        public string Message { get; set; }
        public IDictionary<string, object> Metadata { get; set; }
    }
}