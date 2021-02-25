using System.Threading.Tasks;
using System;
using System.Linq;

namespace Omise.Examples
{
    public class Capability : Example
    {
        public async Task Retrieve__Retrieve()
        {
            var capability = await Client.Capability.Get();

            Console.WriteLine($"supported banks: {string.Join(", ", capability.Banks)}");

            foreach (var paymentMethod in capability.PaymentBackends)
            {
                var key = paymentMethod.Keys.ElementAt(0);
                var value = paymentMethod.Values.ElementAt(0);

                // PaymentMethod identifier
                Console.WriteLine($"payment method: {key}");

                // PaymentMethod supported currencies
                Console.WriteLine($"supported currencies: {string.Join(", ", value.Currencies)}");

                // PaymentMethod supported banks
                if (value.Banks == null) { continue; }
                foreach (var bank in value.Banks)
                {
                    Console.WriteLine($"bank {bank.Name} with code '{bank.Code}' availability: {bank.Active}");
                }
            }
        }
    }
}
