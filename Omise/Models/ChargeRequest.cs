using Newtonsoft.Json;

namespace Omise.Models {
    public class CreateChargeRequest : Request {
        public string Customer { get; set; }
        public string Card { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public bool Capture { get; set; }
        public OffsiteTypes Offsite { get; set; }

        [JsonProperty("return_uri")]
        public string ReturnUri { get; set; }

        public CreateChargeRequest() {
            Capture = true;
        }
    }

    public class UpdateChargeRequest : Request {
        public string Description { get; set; }
    }
}