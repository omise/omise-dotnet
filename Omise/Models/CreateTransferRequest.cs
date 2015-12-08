using System;

namespace Omise.Models {
    public class CreateTransferRequest : Request {
        public long Amount { get; set; }
        public string Recipient { get; set; }
    }
}

