using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Omise.Models;
using System.Text.RegularExpressions;

namespace Omise.Models {
    public class CreateChargeRequest : Request {
        public string Customer { get; set; }
        public string Card { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public bool Capture { get; set; }
        public string ReturnUri { get; set; }

        public CreateChargeRequest() {
            Capture = true;
        }
    }
}
