using System;
using Omise.Models;
using System.Threading.Tasks;

namespace Omise.Example {
    public class CreateCustomerThenChargeExample : Example {
        public async override Task Run() {
            var token = await CreateToken();
            var customer = await Client.Customers.Create(new CreateCustomerRequest
                {
                    Email = Prompt("enter customer's email"),
                    Description = "customer#1234",
                    Card = token.Id
                });

            Print("created customer: {0}", customer.Id);

            var charge = await Client.Charges.Create(new CreateChargeRequest
                {
                    Customer = customer.Id,
                    Amount = (long)(float.Parse(Prompt("enter amount")) * 100.00),
                    Currency = "thb"
                });

            Print("created charge: {0}", charge.Id);
        }
    }
}

