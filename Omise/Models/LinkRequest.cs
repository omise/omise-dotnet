using System;

namespace Omise.Models {
    public class CreateLinkRequest : Request {
        public long Amount { get; set; }
        public string Currency { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Multiple { get; set; }
    }
}
