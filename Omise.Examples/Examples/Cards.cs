using System;
using System.Threading.Tasks;
using Omise.Models;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Omise.Examples
{
    public class Cards : Example
    {
        public async Task List__List()
        {
            var customerId = ExampleInfo.CUST_ID; // "cust_test_5aass4jqqb39x80fkta";
            var cards = await Client.Customers.Customer(customerId).Cards.GetList();
            foreach (var card in cards)
            {
                Console.WriteLine($"card: {card.Id}");
            }
        }

        public async Task Retrieve__Retrieve()
        {
            var customerId = ExampleInfo.CUST_ID; // "cust_test_5aass4jqqb39x80fkta";
            var cardId = ExampleInfo.CARD_ID; // "card_test_5aaswlbxdrzhoornpfe";
            var card = await Client.Customers.Customer(customerId).Cards.Get(cardId);
            Console.WriteLine($"first digits: {card.FirstDigits}");
            Console.WriteLine($"last digits: {card.LastDigits}");
        }

        public async Task Update__Update()
        {
            var customerId = ExampleInfo.CUST_ID; // "cust_test_5aass4jqqb39x80fkta";
            var cardId = ExampleInfo.CARD_ID; // "card_test_5aaswlbxdrzhoornpfe";
            var card = await Client.Customers.Customer(customerId).Cards.Update(cardId, new UpdateCustomerCardParams
            {
                Name = "Somchai Prasert",
                ExpirationMonth = 8,
                ExpirationYear = 2018,
            });

            Console.WriteLine($"updated card name: {card.Id} ({card.Deleted})");
        }

        public async Task Destroy__Destroy()
        {
            var customer = RetrieveCustomerWithCard();
            var card = await Client.Customers.Customer(customer.Id).Cards.Destroy(customer.DefaultCard);
            Console.WriteLine($"destroyed card: {card.Id} of customer {customer.Id}");
        }

        protected Customer RetrieveCustomerWithCard()
        {
            var token = RetrieveToken().Result;
            var customerId = ExampleInfo.CUST_ID_2; // "cust_test_5aass48w2i40qa5ivh9";
            var customer = Client.Customers.Update(customerId, new UpdateCustomerParams
            {
                Card = token.Id
            }).Result;

            return customer;
        }
    }
}
