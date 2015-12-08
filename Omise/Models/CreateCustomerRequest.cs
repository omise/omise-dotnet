using System;

namespace Omise.Models {
    public class CreateCustomerRequest : Request {
        public string Email { get; set; }
        public string Description { get; set; }
        public string Card { get; set; }
    }
}

