using System.Threading.Tasks;
using System;

namespace Omise.Examples
{
    public class Capability : Example
    {
        public async Task Retrieve__Retrieve()
        {
            var capability = await Client.Capability.Get();
            var banks = capability.Banks;
            var paymentMethods = capability.PaymentMethods;

            Console.WriteLine($"country: {capability.Country}");
            Console.WriteLine($"zero interest installments: {capability.ZeroInterestInstallments}");

            foreach (var bank in banks)
            {
                Console.WriteLine($"supported bank: {bank}");
            }

            foreach (var paymentMethod in paymentMethods)
            {
                Console.WriteLine($"supported payment method: {paymentMethod.Name}");

                if (!paymentMethod.Name.Equals("fpx")) {
                    continue;
                }

                foreach (var bank in paymentMethod.Banks) {
                    Console.WriteLine($"fpx bank code: {bank.Code}");
                    Console.WriteLine($"fpx bank name: {bank.Name}");
                    Console.WriteLine($"fpx bank availability: {bank.Active}");
                }
            }
        }
    }
}
