using NUnit.Framework.Internal;
using NUnit.Framework;
using Omise;
using Omise.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Omise.Tests
{
    [TestFixture, Explicit("code provided for manual testing only.")]
    public class RealNetworkTest : OmiseTest
    {
        const string PublicKey = "pkey_test_replaceme";
        const string SecretKey = "skey_test_replaceme";

        [Test]
        public async Task TestRealCharge()
        {
            var client = buildTestClient();
            var token = await client.Tokens.Create(new CreateTokenRequest
            {
                Name = "Omise Co., Ltd",
                Number = "4242424242424242",
                SecurityCode = "123",
                ExpirationMonth = 10,
                ExpirationYear = 2029,
            });
            WriteLine($"created token: ${token.Id}");

            var charge = await client.Charges.Create(new CreateChargeRequest
            {
                Amount = 2000,
                Currency = "usd",
                Card = token.Id,
            });
            WriteLine($"created charge: ${charge.Id}");

            charge = await client.Charges.Update(charge.Id, new UpdateChargeRequest
            {
                Description = "TestRealCharge",
                Metadata = new Dictionary<string, object> {
                    { "test_date", DateTime.UtcNow.ToString() }
                }
            });
            WriteLine($"updated charge: ${charge.Id}");
        }

        Client buildTestClient()
        {
            return new Client(pkey: PublicKey, skey: SecretKey);
        }
    }
}
