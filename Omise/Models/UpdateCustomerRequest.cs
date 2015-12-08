using System;

namespace Omise.Models {
    public class UpdateCustomerRequest : Request {
        public string Email { get; set; }
        public string Description { get; set; }
        public string Card { get; set; }
    }
}

