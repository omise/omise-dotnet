using NUnit.Framework.Internal;
using NUnit.Framework;
using Omise;
using Omise.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Omise.Tests.ManualTesting
{
    [TestFixture, Explicit("code provided for manual testing only.")]
    public class RealNetworkTest : OmiseTest
    {
        const string PublicKey = "pkey_test_5v3grc3gi8o1lilfcqu";
        const string SecretKey = "skey_test_5v3grc64l0m4biolo9l";
        [Test]
        public async Task Create__Create_With_Source_AlipayUPM()
        {
            //string? nullableString = null;
            var client = buildTestClient();
            var source = await client.Sources.Create(new CreatePaymentSourceRequest
            {
                Amount = 2000,
                Currency = "thb",
                Type = OffsiteTypes.ShopeePay,
            });
            var charge = await client.Charges.Create(new CreateChargeRequest()
            {
                Amount = 2000,
                Currency = "thb",
                Source = source,
                ReturnUri = "https://www.example.com"
            });

            Console.WriteLine($"created charge: {charge.Id}");
            

    Console.WriteLine($"created charge: {charge.Description?.Length}");

            throw new Exception("This is an error message.");
        }

        // [Test]
        // public async Task TestRealCharge()
        // {
        //     var client = buildTestClient();
        //     var token = await client.Tokens.Create(new CreateTokenRequest
        //     {
        //         Name = "Omise Co., Ltd",
        //         Number = "4242424242424242",
        //         SecurityCode = "123",
        //         ExpirationMonth = 10,
        //         ExpirationYear = 2029,
        //     });
        //     WriteLine($"created token: ${token.Id}");

        //     var charge = await client.Charges.Create(new CreateChargeRequest
        //     {
        //         Amount = 2000,
        //         Currency = "usd",
        //         Card = token.Id,
        //     });
        //     WriteLine($"created charge: ${charge.Id}");

        //     charge = await client.Charges.Update(charge.Id, new UpdateChargeRequest
        //     {
        //         Description = "TestRealCharge",
        //         Metadata = new Dictionary<string, object> {
        //             { "test_date", DateTime.UtcNow.ToString() }
        //         }
        //     });
        //     WriteLine($"updated charge: ${charge.Id}");
        // }

        // [Test]
        // public async Task TestGettingUsedToken()
        // {
        //     var client = buildTestClient();
        //     var token = await client.Tokens.Create(new CreateTokenRequest
        //     {
        //         Name = "Omise Co., Ltd.",
        //         Number = "4242424242424242",
        //         SecurityCode = "123",
        //         ExpirationMonth = 10,
        //         ExpirationYear = 2029,
        //     });
        //     WriteLine($"created token: {token.Id}");

        //     token = await client.Tokens.Get(token.Id);
        //     WriteLine($"retrieved token: {token.Id}");

        //     var customer = await client.Customers.Create(new CreateCustomerRequest
        //     {
        //         Email = "test@omise.co",
        //         Card = token.Id,
        //     });
        //     WriteLine($"created customer: {customer.Id}");

        //     token = await client.Tokens.Get(token.Id);
        //     WriteLine($"retrieved token again: {token.Id}");
        // }

        Client buildTestClient()
        {
            return new Client(pkey: PublicKey, skey: SecretKey,env:Environments.Staging);
        }
    }
}
