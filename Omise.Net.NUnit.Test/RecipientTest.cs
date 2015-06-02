using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Omise.Net.NUnit.Test
{
    [TestFixture]
    public class RecipientTest : TestBase
    {
        [Test]
        public void TestGetAllRecipients()
        {
            stubResponse(TestHelper.GetJson("AllRecipients.json"));

            var result = client.RecipientService.GetAllRecipients();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Total);
            Assert.AreEqual(0, result.Offset);
            Assert.AreEqual(20, result.Limit);
            Assert.AreEqual(2, result.Collection.Count);

            var recipients = (List<Recipient>)result.Collection;

            Assert.IsInstanceOf<Recipient>(recipients[0]);
            Assert.IsInstanceOf<Recipient>(recipients[1]);

            var first_recipient = recipients[0];
            Assert.AreEqual("recp_test_506zyyark420q0cjtui", first_recipient.Id);
            Assert.AreEqual("John Doe", first_recipient.Name);
            Assert.AreEqual("john.doe@localhost", first_recipient.Email);
            Assert.IsFalse(first_recipient.LiveMode);
            Assert.AreEqual("/recipients/recp_test_506zyyark420q0cjtui", first_recipient.Location);
            Assert.IsTrue(first_recipient.Verified);
            Assert.IsTrue(first_recipient.Active);
            Assert.IsNull(first_recipient.FailureCode);
            Assert.AreEqual("Default recipient", first_recipient.Description);
            Assert.AreEqual(RecipientType.Individual, first_recipient.RecipientType);
            Assert.IsEmpty(first_recipient.TaxId);
            Assert.AreEqual(new DateTime(2015, 5, 30, 4, 28, 9), first_recipient.CreatedAt);
            Assert.IsNotNull(first_recipient.BankAccount);
            Assert.AreEqual("test", first_recipient.BankAccount.Brand);
            Assert.AreEqual("DEFAULT BANK ACCOUNT", first_recipient.BankAccount.Name);
            Assert.AreEqual("6789", first_recipient.BankAccount.LastDigits);

            var second_recipient = recipients[1];
            Assert.AreEqual("recp_test_5086lxnekvk2e6nawed", second_recipient.Id);
            Assert.AreEqual("Test recipient individual", second_recipient.Name);
            Assert.AreEqual("test1@localhost", second_recipient.Email);
            Assert.IsFalse(second_recipient.LiveMode);
            Assert.AreEqual("/recipients/recp_test_5086lxnekvk2e6nawed", second_recipient.Location);
            Assert.IsFalse(second_recipient.Verified);
            Assert.IsFalse(second_recipient.Active);
            Assert.IsNull(second_recipient.FailureCode);
            Assert.AreEqual("Test recipient new description", second_recipient.Description);
            Assert.AreEqual(RecipientType.Individual, second_recipient.RecipientType);
            Assert.AreEqual("abc123456789", second_recipient.TaxId);
            Assert.AreEqual(new DateTime(2015, 6, 2, 5, 8, 39), second_recipient.CreatedAt);
            Assert.IsNotNull(second_recipient.BankAccount);
            Assert.AreEqual("test", second_recipient.BankAccount.Brand);
            Assert.AreEqual("test bank account", second_recipient.BankAccount.Name);
            Assert.AreEqual("7890", second_recipient.BankAccount.LastDigits);
        }

        [Test]
        public void TestGetRecipient()
        {
            stubResponse(TestHelper.GetJson("Recipient.json"));
            var recipient = client.RecipientService.GetRecipient("recp_test_5086lxnekvk2e6nawed");
            Assert.IsNotNull(recipient);
            Assert.AreEqual("recp_test_5086lxnekvk2e6nawed", recipient.Id);
            Assert.AreEqual("Test recipient 1", recipient.Name);
            Assert.AreEqual("test1@localhost", recipient.Email);
            Assert.IsNull(recipient.Description);
            Assert.AreEqual(RecipientType.Corporation, recipient.RecipientType);
            Assert.IsNull(recipient.TaxId);
            Assert.IsFalse(recipient.Verified);
            Assert.IsFalse(recipient.Active);
            Assert.IsNull(recipient.FailureCode);
            Assert.AreEqual("test", recipient.BankAccount.Brand);
            Assert.AreEqual("7890", recipient.BankAccount.LastDigits);
            Assert.AreEqual("test bank account", recipient.BankAccount.Name);

            Assert.AreEqual(new DateTime(2015, 6, 2, 5, 8, 39), recipient.CreatedAt);
        }

        [Test]
        public void TestCreateRecipient()
        {
            var recipientInfo = new RecipientCreateInfo();
            recipientInfo.Name = "Test recipient 1";
            recipientInfo.Email = "test1@localhost";
            recipientInfo.RecipientType = RecipientType.Corporation;
            recipientInfo.BankAccount = new BankAccountInfo()
            {
                Brand = "test",
                Number = "1234567890",
                Name = "test bank account"
            };

            stubResponse(TestHelper.GetJson("Recipient.json"));
            var recipient = client.RecipientService.CreateRecipient(recipientInfo);
            Assert.IsNotNull(recipient);
            Assert.AreEqual("recp_test_5086lxnekvk2e6nawed", recipient.Id);
            Assert.AreEqual("Test recipient 1", recipient.Name);
            Assert.AreEqual("test1@localhost", recipient.Email);
            Assert.IsNull(recipient.Description);
            Assert.AreEqual(RecipientType.Corporation, recipient.RecipientType);
            Assert.IsNull(recipient.TaxId);
            Assert.IsFalse(recipient.Verified);
            Assert.IsFalse(recipient.Active);
            Assert.IsNotNull(recipient.BankAccount);
            Assert.AreEqual("test", recipient.BankAccount.Brand);
            Assert.AreEqual("test bank account", recipient.BankAccount.Name);
            Assert.AreEqual("7890", recipient.BankAccount.LastDigits);
            Assert.AreEqual(new DateTime(2015, 6, 2, 5, 8, 39), recipient.CreatedAt);
        }

        [Test]
        public void TestUpdateRecipient()
        {
            var recipientUpdateInfo = new RecipientUpdateInfo();
            recipientUpdateInfo.Id = "recp_test_5086lxnekvk2e6nawed";
            recipientUpdateInfo.Name = "Test recipient individual";
            recipientUpdateInfo.Email = "test1@localhost";
            recipientUpdateInfo.TaxId = "abc123456789";
            recipientUpdateInfo.RecipientType = RecipientType.Individual;
            recipientUpdateInfo.Description = "Test recipient new description";

            stubResponse(TestHelper.GetJson("RecipientUpdated.json"));
            var recipient = client.RecipientService.UpdateRecipient(recipientUpdateInfo);
            Assert.AreEqual("recp_test_5086lxnekvk2e6nawed", recipient.Id);
            Assert.AreEqual("Test recipient individual", recipient.Name);
            Assert.AreEqual("test1@localhost", recipient.Email);
            Assert.AreEqual("Test recipient new description", recipient.Description);
            Assert.AreEqual(RecipientType.Individual, recipient.RecipientType);
            Assert.AreEqual("abc123456789", recipient.TaxId);
            Assert.IsFalse(recipient.Verified);
            Assert.IsFalse(recipient.Active);
            Assert.IsNull(recipient.FailureCode);
            Assert.AreEqual("test", recipient.BankAccount.Brand);
            Assert.AreEqual("7890", recipient.BankAccount.LastDigits);
            Assert.AreEqual("test bank account", recipient.BankAccount.Name);
            Assert.AreEqual(new DateTime(2015, 6, 2, 5, 8, 39), recipient.CreatedAt);
        }

        [Test]
        public void TestUpdateRecipientBankAccount()
        {
            var recipientUpdateInfo = new RecipientUpdateInfo();
            recipientUpdateInfo.Id = "recp_test_5086lxnekvk2e6nawed";
            recipientUpdateInfo.Name = "Test recipient individual";
            recipientUpdateInfo.Email = "test1@localhost";
            recipientUpdateInfo.TaxId = "abc123456789";
            recipientUpdateInfo.RecipientType = RecipientType.Individual;
            recipientUpdateInfo.Description = "Test recipient new description";
            recipientUpdateInfo.BankAccount = new BankAccountInfo()
            {
                Brand = "bbl",
                Name = "Test bbl bank account",
                Number = "123456789"
            };

            stubResponse(TestHelper.GetJson("RecipientUpdatedBankAccount.json"));
            var recipient = client.RecipientService.UpdateRecipient(recipientUpdateInfo);
            Assert.IsNotNull(recipient);
            Assert.AreEqual("recp_test_5086lxnekvk2e6nawed", recipient.Id);
            Assert.AreEqual("Test recipient individual", recipient.Name);
            Assert.AreEqual("test1@localhost", recipient.Email);
            Assert.AreEqual("Test recipient new description", recipient.Description);
            Assert.AreEqual(RecipientType.Individual, recipient.RecipientType);
            Assert.AreEqual("abc123456789", recipient.TaxId);
            Assert.IsFalse(recipient.Verified);
            Assert.IsFalse(recipient.Active);
            Assert.IsNotNull(recipient.BankAccount);
            Assert.AreEqual("bbl", recipient.BankAccount.Brand);
            Assert.AreEqual("Test bbl bank account", recipient.BankAccount.Name);
            Assert.AreEqual("6789", recipient.BankAccount.LastDigits);
            Assert.AreEqual(new DateTime(2015, 6, 2, 5, 8, 39), recipient.CreatedAt);
        }

        [Test]
        public void TestDeleteRecipient()
        {
            stubResponse(@"{
                        'object': 'recipient',
                        'id': 'recp_test_5086lxnekvk2e6nawed',
                        'livemode': false,
                        'deleted': true
                        }");

            var result = client.RecipientService.DeleteRecipient("recp_test_5086lxnekvk2e6nawed");
            Assert.AreEqual("recp_test_5086lxnekvk2e6nawed", result.Id);
            Assert.IsTrue(result.Deleted);
        }
    }
}

