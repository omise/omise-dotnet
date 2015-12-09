using System;
using NUnit.Framework;
using Omise.Resources;
using Newtonsoft.Json.Schema;
using Omise.Models;

namespace Omise.Tests.Resources {
    [TestFixture]
    public class RecipientResourceTest : ResourceTest<RecipientResource> {
        [Test]
        public async void TestGetList() {
            await Resource.GetList();
            AssertRequest("GET", "https://api.omise.co/recipients");
        }

        [Test]
        public async void TestGet() {
            await Resource.Get("recp_test_123");
            AssertRequest("GET", "https://api.omise.co/recipients/recp_test_123");
        }

        [Test]
        public async void TestCreate() {
            await Resource.Create(BuildCreateRequest());
            AssertRequest("POST", "https://api.omise.co/recipients");
        }

        [Test]
        public async void TestUpdate() {
            await Resource.Update("recp_test_123", BuildUpdateRequest());
            AssertRequest("PATCH", "https://api.omise.co/recipients/recp_test_123");
        }

        [Test]
        public async void TestDestroy() {
            await Resource.Destroy("recp_test_123");
            AssertRequest("DELETE", "https://api.omise.co/recipients/recp_test_123");
        }

        [Test]
        public void TestCreateRecipientRequest() {
            AssertSerializedRequest(BuildCreateRequest(),
                "name=John%20Doe&" +
                "email=john.doe%40example.com&" +
                "description=Waaat%3F&" +
                "type=corporation&" +
                "tax_id=123&" +
                "bank_account[brand]=KBank&" +
                "bank_account[number]=1234-567-89-0&" +
                "bank_account[name]=Secret%20Stash"
            );
        }

        [Test]
        public void TestUpdateRecipientRequest() {
            AssertSerializedRequest(BuildUpdateRequest(),
                "name=John%20Doe&" +
                "email=john.doe%40example.com&" +
                "description=I%27m%20up-to-date&" +
                "type=individual&" +
                "tax_id=456&" +
                "bank_account[brand]=BBL&" +
                "bank_account[number]=987654321&" +
                "bank_account[name]=Accounts"
            );
        }

        protected CreateRecipientRequest BuildCreateRequest() {
            return new CreateRecipientRequest
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Description = "Waaat?",
                Type = RecipientType.Corporation,
                TaxID = "123",
                BankAccount = new BankAccountRequest
                {
                    Brand = "KBank",
                    Name = "Secret Stash",
                    Number = "1234-567-89-0",
                }
            };
        }

        protected UpdateRecipientRequest BuildUpdateRequest() {
            return new UpdateRecipientRequest
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Description = "I'm up-to-date",
                Type = RecipientType.Individual,
                TaxID = "456",
                BankAccount = new BankAccountRequest
                {
                    Brand = "BBL",
                    Name = "Accounts",
                    Number = "987654321",
                }
            };
        }

        protected override RecipientResource BuildResource(IRequester requester) {
            return new RecipientResource(requester);
        }
    }
}

