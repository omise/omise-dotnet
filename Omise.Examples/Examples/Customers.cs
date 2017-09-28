using Omise.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Omise.Examples
{
    public class Customers : Example
    {
        public async Task List__List()
        {
            var customers = await Client.Customers.GetList(order: Ordering.Chronological);
            Console.WriteLine($"total customers: {customers.Total}");
        }

        public async Task Retrieve__Retrieve()
        {
            var customerId = "cust_test_5665s8r7it17q4wo78a";
            var customer = await Client.Customers.Get(customerId);
            Console.WriteLine($"customer's email: {customer.Email}");
        }

        public async Task Create__Create_Simple()
        {
            var customer = await Client.Customers.Create(new CreateCustomerRequest
            {
                Email = "john.doe@example.com",
                Description = "John Doe (id: 30)",
                Metadata = new Dictionary<string, object>
                {
                    { "user_id", 30 }
                }
            });

            Console.WriteLine($"created customer: {customer.Id}");
        }

        public async Task Create__Attach_Card()
        {
            var token = await RetrieveToken();
            var customer = await Client.Customers.Create(new CreateCustomerRequest
            {
                Email = "john.doe@example.com",
                Description = "John Doe (id: 30)",
                Metadata = new Dictionary<string, object>
                {
                    { "user_id", 30 }
                },
                Card = token.Id,
            });

            Console.WriteLine($"created customer: {customer.Id}");
        }

        public async Task Update__Update_Simple()
        {
            var customerId = "cust_test_5665s8r7it17q4wo78a";
            var customer = await Client.Customers.Update(customerId, new UpdateCustomerRequest
            {
                Email = "john.smith@example.com",
                Description = "John Smith",
                Metadata = new Dictionary<string, object>
                {
                    { "user_id", 99 }
                }
            });

            Console.WriteLine($"updated customer: {customer.Id}");
        }

        public async Task Update__Attach_Card()
        {
            var token = await RetrieveToken();

            var customerId = "cust_test_5665s8r7it17q4wo78a";
            var customer = await Client.Customers.Update(customerId, new UpdateCustomerRequest
            {
                Card = token.Id
            });

            Console.WriteLine($"updated customer: {customer.Id}");
        }

        public async Task Destroy__Destroy()
        {
            var customer = RetrieveCustomer();
            customer = await Client.Customers.Destroy(customer.Id);
            Console.WriteLine($"destroy customer: {customer.Id}");
        }

        protected Customer RetrieveCustomer()
        {
            return Client.Customers.Create(new CreateCustomerRequest
            {
                Email = "john.doe@example.com",
                Description = "wat",
                Metadata = new Dictionary<string, object>
                {
                    { "hello", "world" }
                }
            }).Result;
        }
    }
}
