using Omise.Models;
using System.Threading.Tasks;
using System;

namespace Omise.Examples
{
    public class Tokens : Example
    {
        public async Task Create__Create()
        {
            var token = await Client.Tokens.Create(new CreateTokenRequest
            {
                Name = "John Doe",
                Number = "4242424242424242",
                ExpirationMonth = 10,
                ExpirationYear = 2019,
                SecurityCode = "123",
            });

            Console.WriteLine($"created token: {token.Id}");
        }

        public async Task Retrieve__Retrieve()
        {
            var tokenId = RetrieveTokenId();
            var token = await Client.Tokens.Get(tokenId);
            Console.WriteLine($"token already used? {token.Used}");
        }

        protected string RetrieveTokenId()
        {
            return RetrieveToken().Result.Id;
        }
    }
}
