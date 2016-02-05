using System;
using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Example {
    public abstract class Example {
        protected Client Client { get; private set; }

        protected Example() {
            var pkey = Environment.GetEnvironmentVariable("OMISE_PUBKEY") ?? Prompt("omise public key");
            var skey = Environment.GetEnvironmentVariable("OMISE_KEY") ?? Prompt("omise secret key");

            Client = new Client(pkey, skey);
        }

        public abstract Task Run();

        protected async Task<Token> CreateToken() {
            var token = await Client.Tokens.Create(new CreateTokenRequest
                {
                    Number = Prompt("enter you card number"),
                    Name = Prompt("enter your card name"),
                    SecurityCode = "123",
                    ExpirationMonth = 1,
                    ExpirationYear = DateTime.Now.Year + 1,
                });

            Print("created token: {0}", token.Id); 
            return token;
        }

        protected void Print(string message, params object[] args) {
            Console.WriteLine(string.Format(message, args));
        }

        protected string Prompt(string message) {
            Console.Write(message + ": ");
            return Console.ReadLine();
        }
    }
}