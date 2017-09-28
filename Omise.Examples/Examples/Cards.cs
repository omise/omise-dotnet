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
            var customerId = "cust_test_566l662pnj240tgz61k";
            var cards = await Client.Customer(customerId).Cards.GetList();
            foreach (var card in cards)
            {
                Console.WriteLine($"card: {card.Id} ({card.LastDigits})");
            }
        }

        public async Task Retrieve__Retrieve()
        {
            var customerId = "cust_test_566l662pnj240tgz61k";
            var cardId = "card_test_566l661ty3h314lpl9e";
            var card = await Client.Customer(customerId).Cards.Get(cardId);
            Console.WriteLine($"last digits: {card.LastDigits}");
        }

        public async Task Update__Update()
        {
            var customerId = "cust_test_566l662pnj240tgz61k";
            var cardId = "card_test_566l661ty3h314lpl9e";
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
            var customerId = "cust_test_58cqst5etwlehfwec90";
            var customer = Client.Customers.Update(customerId, new UpdateCustomerRequest
            {
                Card = token.Id
            }).Result;

            return customer;
        }
    }
}
