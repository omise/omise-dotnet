using System;

namespace Omise.Models {
    public class UpdateCardRequest : Request {
        public string Name { get; set; }
        public string City { get; set ; }
        public string PostalCode { get; set ; }

        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set ; }
    }
}

