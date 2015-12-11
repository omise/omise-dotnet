using System;
using Omise.Models;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;

namespace Omise.Example {
    class MainClass {
        public static void Main(string[] args) {
            var pkey = Environment.GetEnvironmentVariable("OMISE_PUBKEY") ?? Prompt("omise public key");
            var skey = Environment.GetEnvironmentVariable("OMISE_KEY") ?? Prompt("omise secret key");

            var client = new Client(pkey, skey);
            var token = client.Tokens
                .Create(new CreateTokenRequest
                {
                    Number = Prompt("enter you card number"),
                    Name = Prompt("enter your card name"),
                    SecurityCode = "123",
                    ExpirationMonth = 1,
                    ExpirationYear = DateTime.Now.Year + 1,
                })
                .Result;

            var charge = client.Charges
                .Create(new CreateChargeRequest
                {
                    Amount = int.Parse(Prompt("how much you want to charge")),
                    Currency = "thb",
                    Card = token.Id
                })
                .Result;

            Console.WriteLine("charge: " + charge.Id);
        }

        public static string Prompt(string prompt) {
            Console.Write(prompt + ": ");
            return Console.ReadLine();
        }
    }
}
