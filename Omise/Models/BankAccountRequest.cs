namespace Omise.Models {
    public class BankAccountRequest : Request {
        public string Brand { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
    }
}