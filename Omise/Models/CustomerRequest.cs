namespace Omise.Models
{
    public class CreateCustomerRequest : CustomerRequest
    {
    }

    public class UpdateCustomerRequest : CustomerRequest
    {
    }

    public abstract class CustomerRequest : Request
    {
        public string Email { get; set; }
        public string Description { get; set; }
        public string Card { get; set; }
    }
}