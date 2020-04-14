﻿using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Models;
using Omise.Resources;

namespace Omise.Tests.Resources
{
    [TestFixture]
    public class RecipientResourceTest : ResourceTest<RecipientResource>
    {
        const string RecipientId = "recp_test_50894vc13y8z4v51iuc";

        [Test]
        public async Task TestGetList()
        {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/recipients");
        }

        [Test]
        public async Task TestGet()
        {
            await Resource.Get(RecipientId);
            AssertRequest("GET", "https://api.omise.co/recipients/{0}", RecipientId);
        }

        [Test]
        public async Task TestCreate()
        {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://api.omise.co/recipients");
        }

        [Test]
        public async Task TestUpdate()
        {
            await Resource.Update(RecipientId, BuildUpdateRequest());
            AssertRequest("PATCH", "https://api.omise.co/recipients/{0}", RecipientId);
        }

        [Test]
        public async Task TestDestroy()
        {
            await Resource.Destroy(RecipientId);
            AssertRequest("DELETE", "https://api.omise.co/recipients/{0}", RecipientId);
        }

        [Test]
        public void TestCreateRecipientRequest()
        {
            AssertSerializedRequest(
                BuildCreateRequest(),
                new Dictionary<string, object>
                {
                    { "name", "John Doe" },
                    { "email", "john.doe@example.com" },
                    { "description", "Waaat?" },
                    { "type", "corporation" },
                    { "tax_id", "123" },
                    { "bank_account", new Dictionary<string, object>
                        {
                            { "brand", "KBank" },
                            { "number", "1234-567-89-0" },
                            { "name", "Secret Stash" },
                        }
                    }
                }
            );
        }

        [Test]
        public void TestUpdateRecipientRequest()
        {
            AssertSerializedRequest(
                BuildUpdateRequest(),
                new Dictionary<string, object>
                {
                    { "name", "John Doe" },
                    { "email", "john.doe@example.com" },
                    { "description", "I'm up-to-date" },
                    { "type", "individual" },
                    { "tax_id", "456" },
                    { "bank_account", new Dictionary<string, object>
                        {
                            { "brand", "BBL" },
                            { "number", "987654321" },
                            { "name", "Accounts" },
                        }
                    }
                }
            );
        }

        [Test]
        public async Task TestFixturesGetList()
        {
            var list = await Fixtures.GetList();
            Assert.AreEqual(1, list.Count);

            var recipient = list[0];
            Assert.AreEqual(RecipientId, recipient.Id);
            Assert.AreEqual("6789", recipient.BankAccount.LastDigits);
        }

        [Test]
        public async Task TestFixturesGet()
        {
            var recipient = await Fixtures.Get(RecipientId);
            Assert.AreEqual(RecipientId, recipient.Id);
            Assert.AreEqual("6789", recipient.BankAccount.LastDigits);
        }

        [Test]
        public async Task TestFixturesCreate()
        {
            var recipient = await Fixtures.Create(new CreateRecipientParams());
            Assert.AreEqual(RecipientId, recipient.Id);
            Assert.AreEqual("6789", recipient.BankAccount.LastDigits);
        }

        [Test]
        public async Task TestFixturesUpdate()
        {
            var recipient = await Fixtures.Update(RecipientId, new UpdateRecipientParams());
            Assert.AreEqual(RecipientId, recipient.Id);
            Assert.AreEqual("john@doe.com", recipient.Email);
        }

        [Test]
        public async Task TestFixturesDestroy()
        {
            var recipient = await Fixtures.Destroy(RecipientId);
            Assert.AreEqual(RecipientId, recipient.Id);
            Assert.IsTrue(recipient.Deleted);
        }

        protected CreateRecipientParams BuildCreateRequest()
        {
            return new CreateRecipientParams
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Description = "Waaat?",
                Type = RecipientType.Corporation,
                TaxId = "123",
                BankAccount = new CreateBankAccountParams
                {
                    Brand = "KBank",
                    Name = "Secret Stash",
                    Number = "1234-567-89-0",
                }
            };
        }

        protected UpdateRecipientParams BuildUpdateRequest()
        {
            return new UpdateRecipientParams
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Description = "I'm up-to-date",
                Type = RecipientType.Individual,
                TaxId = "456",
                BankAccount = new CreateBankAccountParams
                {
                    Brand = "BBL",
                    Name = "Accounts",
                    Number = "987654321",
                }
            };
        }

        protected override RecipientResource BuildResource(IRequester requester)
        {
            return new RecipientResource(requester);
        }
    }
}

