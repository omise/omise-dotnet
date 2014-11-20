using System;
using NUnit.Framework;

namespace Omise.Net.NUnit.Test
{
    [TestFixture]
    public class RecipientTest: TestBase
    {
        [Test]
        public void TestGetRecipient()
        {
            string json = @"{
                          'object': 'recipient',
                          'id': 'recp_test_4y355pimyomptde4cvo',
                          'livemode': false,
                          'location': '/recipients/recp_test_4y355pimyomptde4cvo',
                          'name': 'Test Recipient 1',
                          'email': 'test_recp@localhost',
                          'description': 'Test recipient description',
                          'tax_id': '1234567890',
                          'recipient_type': 'individual',
                          'created': '2014-11-17T05:55:32Z',
                          'default_bank_account': 'bnk_test_4y355piolnoh4e6cohd',
                          'bank_accounts': {
                            'object': 'list',
                            'from': '1970-01-01T07:00:00+07:00',
                            'to': '2014-11-17T12:55:32+07:00',
                            'offset': 0,
                            'limit': 20,
                            'total': 1,
                            'data': [
                              {
                                'object': 'recipient_bank_account',
                                'id': 'bnk_test_4y355piolnoh4e6cohd',
                                'location': '/recipients/recp_test_4y355pimyomptde4cvo/bank_accounts/bnk_test_4y355piolnoh4e6cohd',
                                'bank_id': 'bbl',
                                'bank_account_no': '1234567890',
                                'bank_account_name': 'test bank account',
                                'created': '2014-11-17T05:55:32Z'
                              }
                            ],
                            'location': '/recipients/recp_test_4y355pimyomptde4cvo/bank_accounts'
                          }
                        }";

            stubResponse(json);
            var recipient = client.RecipientService.GetRecipient("recp_test_4y355pimyomptde4cvo");
            Assert.IsNotNull(recipient);
            Assert.AreEqual("recp_test_4y355pimyomptde4cvo", recipient.Id);
            Assert.AreEqual("Test Recipient 1", recipient.Name);
            Assert.AreEqual("test_recp@localhost", recipient.Email);
            Assert.AreEqual("Test recipient description", recipient.Description);
            Assert.AreEqual(RecipientType.Individual, recipient.RecipientType);
            Assert.AreEqual("1234567890", recipient.TaxId);
            Assert.AreEqual("bnk_test_4y355piolnoh4e6cohd", recipient.DefaultBankAccountId);
            Assert.AreEqual(1, recipient.BankAccountCollection.Total);
            Assert.AreEqual(new DateTime(2014, 11, 17, 5, 55, 32), recipient.CreatedAt);
        }

        [Test]
        public void TestCreateRecipient()
        {
            var recipientInfo = new RecipientInfo();
            recipientInfo.Name = "Test Recipient 1";
            recipientInfo.Email = "test_recp@localhost";
            recipientInfo.TaxId = "1234567890";
            recipientInfo.RecipientType = RecipientType.Individual;
            recipientInfo.Description = "Test recipient description";

            string json = @"{
                          'object': 'recipient',
                          'id': 'recp_test_4y355pimyomptde4cvo',
                          'livemode': false,
                          'location': '/recipients/recp_test_4y355pimyomptde4cvo',
                          'name': 'Test Recipient 1',
                          'email': 'test_recp@localhost',
                          'description': 'Test recipient description',
                          'tax_id': '1234567890',
                          'recipient_type': 'individual',
                          'created': '2014-11-17T05:55:32Z',
                          'default_bank_account': 'bnk_test_4y355piolnoh4e6cohd',
                          'bank_accounts': {
                            'object': 'list',
                            'from': '1970-01-01T07:00:00+07:00',
                            'to': '2014-11-17T12:55:32+07:00',
                            'offset': 0,
                            'limit': 20,
                            'total': 1,
                            'data': [
                              {
                                'object': 'recipient_bank_account',
                                'id': 'bnk_test_4y355piolnoh4e6cohd',
                                'location': '/recipients/recp_test_4y355pimyomptde4cvo/bank_accounts/bnk_test_4y355piolnoh4e6cohd',
                                'bank_id': 'bbl',
                                'bank_account_no': '1234567890',
                                'bank_account_name': 'test bank account',
                                'created': '2014-11-17T05:55:32Z'
                              }
                            ],
                            'location': '/recipients/recp_test_4y355pimyomptde4cvo/bank_accounts'
                          }
                        }";

            stubResponse(json);
            var recipient = client.RecipientService.CreateRecipient(recipientInfo);
            Assert.IsNotNull(recipient);
            Assert.AreEqual("recp_test_4y355pimyomptde4cvo", recipient.Id);
            Assert.AreEqual("Test Recipient 1", recipient.Name);
            Assert.AreEqual("test_recp@localhost", recipient.Email);
            Assert.AreEqual("Test recipient description", recipient.Description);
            Assert.AreEqual(RecipientType.Individual, recipient.RecipientType);
            Assert.AreEqual("1234567890", recipient.TaxId);
            Assert.AreEqual("bnk_test_4y355piolnoh4e6cohd", recipient.DefaultBankAccountId);
            Assert.AreEqual(1, recipient.BankAccountCollection.Total);
            Assert.AreEqual(new DateTime(2014, 11, 17, 5, 55, 32), recipient.CreatedAt);
        }

        [Test]
        public void TestUpdateRecipient()
        {
            var recipientInfo = new RecipientInfo();
            recipientInfo.Id = "recp_test_4y355pimyomptde4cvo";
            recipientInfo.Name = "Test Corporate Recipient";
            recipientInfo.Email = "test_recp@localhost";
            recipientInfo.TaxId = "abc123456789";
            recipientInfo.RecipientType = RecipientType.Corporation;
            recipientInfo.Description = "Test recipient new description";

            string json = @"{
                          'object': 'recipient',
                          'id': 'recp_test_4y355pimyomptde4cvo',
                          'livemode': false,
                          'location': '/recipients/recp_test_4y355pimyomptde4cvo',
                          'name': 'Test Corporate Recipient',
                          'email': 'test_recp@localhost',
                          'description': 'Test recipient new description',
                          'tax_id': 'abc123456789',
                          'recipient_type': 'corporation',
                          'created': '2014-11-17T05:55:32Z',
                          'default_bank_account': 'bnk_test_4y355piolnoh4e6cohd',
                          'bank_accounts': {
                            'object': 'list',
                            'from': '1970-01-01T07:00:00+07:00',
                            'to': '2014-11-17T12:55:32+07:00',
                            'offset': 0,
                            'limit': 20,
                            'total': 1,
                            'data': [
                              {
                                'object': 'recipient_bank_account',
                                'id': 'bnk_test_4y355piolnoh4e6cohd',
                                'location': '/recipients/recp_test_4y355pimyomptde4cvo/bank_accounts/bnk_test_4y355piolnoh4e6cohd',
                                'bank_id': 'bbl',
                                'bank_account_no': '1234567890',
                                'bank_account_name': 'test bank account',
                                'created': '2014-11-17T05:55:32Z'
                              }
                            ],
                            'location': '/recipients/recp_test_4y355pimyomptde4cvo/bank_accounts'
                          }
                        }";

            stubResponse(json);
            var recipient = client.RecipientService.UpdateRecipient(recipientInfo);
            Assert.AreEqual("recp_test_4y355pimyomptde4cvo", recipient.Id);
            Assert.AreEqual("Test Corporate Recipient", recipient.Name);
            Assert.AreEqual("test_recp@localhost", recipient.Email);
            Assert.AreEqual("Test recipient new description", recipient.Description);
            Assert.AreEqual(RecipientType.Corporation, recipient.RecipientType);
            Assert.AreEqual("abc123456789", recipient.TaxId);
            Assert.AreEqual("bnk_test_4y355piolnoh4e6cohd", recipient.DefaultBankAccountId);
            Assert.AreEqual(1, recipient.BankAccountCollection.Total);
            Assert.AreEqual(new DateTime(2014, 11, 17, 5, 55, 32), recipient.CreatedAt);
        }

        [Test]
        public void TestDeleteRecipient()
        {
            stubResponse(@"{
                        'object': 'recipient',
                        'id': 'recp_test_4y355pimyomptde4cvo',
                        'livemode': false,
                        'deleted': true
                        }");

            var result = client.RecipientService.DeleteRecipient("recp_test_4y355pimyomptde4cvo");
            Assert.AreEqual("recp_test_4y355pimyomptde4cvo", result.Id);
            Assert.IsTrue(result.Deleted);
        }

        [Test]
        public void TestGetBankAccount()
        {
            string json = @"{
                            'object': 'recipient_bank_account',
                            'id': 'bnk_test_4y355piolnoh4e6cohd',
                            'location': '/recipients/recp_test_4y355pimyomptde4cvo/bank_accounts/bnk_test_4y355piolnoh4e6cohd',
                            'bank_id': 'bbl',
                            'bank_account_no': '1234567890',
                            'bank_account_name': 'John Doe',
                            'created': '2014-11-17T05:55:32Z'
                         }";

            stubResponse(json);
            var result = client.RecipientService.GetBankAccount("recp_test_4y355pimyomptde4cvo", "bnk_test_4y355piolnoh4e6cohd");

            Assert.AreEqual("bnk_test_4y355piolnoh4e6cohd", result.Id);
            Assert.AreEqual("bbl", result.BankId);
            Assert.AreEqual("John Doe", result.BankAccountName);
            Assert.AreEqual("1234567890", result.BankAccountNumber);
        }

        [Test]
        public void TestUpdateBankAccount()
        {
            var bankAccountInfo = new BankAccountInfo();
            bankAccountInfo.Id = "bnk_test_4y355piolnoh4e6cohd";
            bankAccountInfo.BankId = "tmb";
            bankAccountInfo.BankAccountName = "John Doe";
            bankAccountInfo.BankAccountNumber = "111111111111";

            string json = @"{
                            'object': 'recipient_bank_account',
                            'id': 'bnk_test_4y355piolnoh4e6cohd',
                            'location': '/recipients/recp_test_4y355pimyomptde4cvo/bank_accounts/bnk_test_4y355piolnoh4e6cohd',
                            'bank_id': 'tmb',
                            'bank_account_no': '111111111111',
                            'bank_account_name': 'John Doe',
                            'created': '2014-11-17T05:55:32Z'
                            }";

            stubResponse(json);
            var result = client.RecipientService.UpdateBankAccount("recp_test_4y355pimyomptde4cvo", bankAccountInfo);

            Assert.AreEqual("tmb", result.BankId);
            Assert.AreEqual("John Doe", result.BankAccountName);
            Assert.AreEqual("111111111111", result.BankAccountNumber);
        }

        [Test]
        public void TestDeleteBankAccount()
        {
            stubResponse(@"{
                        'object': 'recipient_bank_account',
                        'id': 'bnk_test_4y355piolnoh4e6cohd',
                        'livemode': false,
                        'deleted': true
                        }");

            var result = client.RecipientService.DeleteBankAccount("recp_test_4y355pimyomptde4cvo", "bnk_test_4y355piolnoh4e6cohd");
            Assert.AreEqual("bnk_test_4y355piolnoh4e6cohd", result.Id);
            Assert.IsTrue(result.Deleted); 
        }
    }
}

