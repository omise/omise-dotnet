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
            var customerId = TestInfo.CUST_ID;
            var cards = await Client.Customer(customerId).Cards.GetList();
            foreach (var card in cards)
            {
                Console.WriteLine($"card: {card.Id} ({card.LastDigits})");
            }
        }

        public async Task Retrieve__Retrieve()
        {
            var customerId = TestInfo.CUST_ID;
            var cardId = TestInfo.CARD_ID;
            var card = await Client.Customer(customerId).Cards.Get(cardId);
            Console.WriteLine($"last digits: {card.LastDigits}");
        }

        public async Task Update__Update()
        {
            var customerId = TestInfo.CUST_ID;
            var cardId = TestInfo.CARD_ID;
            var card = await Client.Customer(customerId).Cards.Update(cardId, new UpdateCardRequest
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
            var card = await Client.Customer(customer.Id).Cards.Destroy(customer.DefaultCard);
            Console.WriteLine($"destroyed card: {card.Id} of customer {customer.Id}");
        }

        protected Customer RetrieveCustomerWithCard()
        {
            var token = RetrieveToken().Result;
            var customerId = TestInfo.CUST_ID_2;
            var customer = Client.Customers.Update(customerId, new UpdateCustomerRequest
            {
                Card = token.Id
            }).Result;

            return customer;
        }
    }
}
