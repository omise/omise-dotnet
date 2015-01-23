using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Omise.Net.NUnit.Test
{
    [TestFixture]
    public class ChargeTest:TestBase
    {
        [Test]
        public void TestChargeAmountValidations()
        {
            var charge = new ChargeCreateInfo();
            Assert.False(charge.Valid);
            Assert.Contains(new KeyValuePair<string, string>("Amount", "must be greater than 0"), charge.Errors);
        }

        [Test]
        public void TestChargeCurrencyValidations()
        {
            var charge = new ChargeCreateInfo();
            charge.Amount = 10000;
            Assert.False(charge.Valid);
            Assert.Contains(new KeyValuePair<string, string>("Currency", "cannot be blank"), charge.Errors);
        }

        [Test]
        public void TestGetCharge()
        {
            stubResponse(@"{
								    'object': 'charge',
								    'id': '123',
								    'livemode': false,
								    'location': '/charges/123',
								    'amount': 10000,
								    'currency': 'thb',
								    'description': 'test update',
								    'capture': true,
								    'authorized': false,
								    'captured': false,
								    'transaction': null,
								    'return_uri': 'http://www.lvh.me:3000/?payment-result=success',
								    'reference': '123',
								    'authorize_uri': 'http://api.lvh.me:3000/payments/123/authorize',
								    'card': {
								        'object': 'card',
								        'id': '123',
								        'livemode': false,
								        'country': '',
								        'city': null,
								        'postal_code': null,
								        'financing': '',
								        'last_digits': '4242',
								        'brand': 'Visa',
								        'expiration_month': 9,
								        'expiration_year': 2017,
								        'fingerprint': '123',
								        'name': 'test card',
								        'created': '2014-10-02T08:08:11Z'
								    },
								    'customer': null,
								    'ip': null,
								    'created': '2014-10-02T08:08:11Z'
								}");
            var result = client.ChargeService.GetCharge("123");
            Assert.IsNotNullOrEmpty(result.Id);
            Assert.AreEqual(10000, result.Amount);
            Assert.AreEqual("thb", result.Currency);
            Assert.IsFalse(result.Captured);
            Assert.AreEqual(new DateTime(2014, 10, 2, 8, 8, 11), result.CreatedAt);
            Assert.IsNotNull(result.Card);
            Assert.AreEqual("4242", result.Card.LastDigits);
            Assert.AreEqual("test card", result.Card.Name);
            Assert.AreEqual(9, result.Card.ExpirationMonth);
            Assert.AreEqual(2017, result.Card.ExpirationYear);
            Assert.AreEqual("123", result.Card.Fingerprint);
            Assert.IsNull(result.Card.Location);
            Assert.IsNullOrEmpty(result.Card.Country);
            Assert.IsNullOrEmpty(result.Card.City);
            Assert.IsNullOrEmpty(result.Card.PostalCode);
            Assert.IsNullOrEmpty(result.Card.Financing);
            Assert.AreEqual(Brand.Visa, result.Card.Brand);
            Assert.AreEqual(new DateTime(2014, 10, 2, 8, 8, 11), result.Card.CreatedAt);
            Assert.False(result.Card.LiveMode);
            Assert.AreEqual("/charges/123", result.Location);
        }

        [Test]
        public void TestCreateChargeWithCardToken()
        {
            var charge = new ChargeCreateInfo();
            charge.Amount = 10000;//100 THB,=> 10000 Satangs
            charge.Currency = "THB";
            charge.Description = "Test charge";
            charge.ReturnUri = "http://localhost:3000/";
            charge.Capture = true;
            charge.CardId = "123";
            stubResponse(@"{
					    'object': 'charge',
					    'id': '123',
					    'livemode': false,
					    'location': '/charges/123',
					    'amount': 10000,
					    'currency': 'thb',
					    'description': 'test charge',
					    'capture': true,
					    'authorized': false,
					    'captured': false,
					    'transaction': null,
					    'return_uri': 'http://www.lvh.me:3000/?payment-result=success',
					    'reference': '123',
					    'authorize_uri': 'http://api.lvh.me:3000/payments/123/authorize',
					    'card': {
					        'object': 'card',
					        'id': '123',
					        'livemode': false,
					        'country': '',
					        'city': null,
					        'postal_code': null,
					        'financing': '',
					        'last_digits': '4242',
					        'brand': 'Visa',
					        'expiration_month': 9,
					        'expiration_year': 2017,
					        'fingerprint': '123',
					        'name': 'test card',
					        'created': '2014-10-02T07:27:30Z'
					    },
					    'customer': null,
					    'ip': null,
					    'created': '2014-10-02T07:30:29Z'
					}");
            var result = client.ChargeService.CreateCharge(charge);
            Assert.AreEqual("123", result.Id);
            Assert.AreEqual(10000, result.Amount);
            Assert.AreEqual("thb", result.Currency);
            Assert.AreEqual(new DateTime(2014, 10, 2, 7, 30, 29), result.CreatedAt);
            Assert.IsNotNull(result.Card);
            Assert.AreEqual("4242", result.Card.LastDigits);
            Assert.AreEqual("test card", result.Card.Name);
            Assert.AreEqual(9, result.Card.ExpirationMonth);
            Assert.AreEqual(2017, result.Card.ExpirationYear);
            Assert.AreEqual("123", result.Card.Fingerprint);
            Assert.IsNull(result.Card.Location);
            Assert.IsNullOrEmpty(result.Card.Country);
            Assert.IsNullOrEmpty(result.Card.City);
            Assert.IsNullOrEmpty(result.Card.PostalCode);
            Assert.IsNullOrEmpty(result.Card.Financing);
            Assert.AreEqual(Brand.Visa, result.Card.Brand);
            Assert.AreEqual(new DateTime(2014, 10, 2, 7, 27, 30), result.Card.CreatedAt);
            Assert.False(result.Card.LiveMode);
            Assert.AreEqual("/charges/123", result.Location);
        }

        [Test]
        public void TestCreateChargeWithCardId()
        {   
            var charge = new ChargeCreateInfo();
            charge.Amount = 10000;//100 THB,=> 10000 Satangs
            charge.Currency = "THB";
            charge.Description = "Test charge";
            charge.ReturnUri = "http://localhost:3000/";
            charge.Capture = true;
            charge.CardId = "123";
            charge.CustomerId = "123";
            stubResponse(@"{
					    'object': 'charge',
					    'id': '123',
					    'livemode': false,
					    'location': '/charges/123',
					    'amount': 10000,
					    'currency': 'thb',
					    'description': 'test charge',
					    'capture': true,
					    'authorized': false,
					    'captured': false,
					    'transaction': null,
					    'return_uri': 'http://www.lvh.me:3000/?payment-result=success',
					    'reference': '123',
					    'authorize_uri': 'http://api.lvh.me:3000/payments/123/authorize',
					    'card': {
					        'object': 'card',
					        'id': '123',
					        'livemode': false,
					        'location': '/customers/123/cards/123',
					        'country': '',
					        'city': null,
					        'postal_code': null,
					        'financing': '',
					        'last_digits': '4242',
					        'brand': 'Visa',
					        'expiration_month': 9,
					        'expiration_year': 2017,
					        'fingerprint': '123',
					        'name': 'test card 2',
					        'created': '2014-10-02T07:39:50Z'
					    },
					    'customer': '123',
					    'ip': null,
					    'created': '2014-10-02T07:40:36Z'
					}");

            var result = client.ChargeService.CreateCharge(charge);
            Assert.IsNotNull(result);
            Assert.AreEqual("123", result.Id);
            Assert.AreEqual(10000, result.Amount);
            Assert.AreEqual("thb", result.Currency);
            Assert.AreEqual(new DateTime(2014, 10, 2, 7, 40, 36), result.CreatedAt);
            Assert.IsNotNull(result.Card);
            Assert.AreEqual("4242", result.Card.LastDigits);
            Assert.AreEqual("test card 2", result.Card.Name);
            Assert.AreEqual(9, result.Card.ExpirationMonth);
            Assert.AreEqual(2017, result.Card.ExpirationYear);
            Assert.AreEqual("123", result.Card.Fingerprint);
            Assert.AreEqual("/customers/123/cards/123", result.Card.Location);
            Assert.IsNullOrEmpty(result.Card.Country);
            Assert.IsNullOrEmpty(result.Card.City);
            Assert.IsNullOrEmpty(result.Card.PostalCode);
            Assert.IsNullOrEmpty(result.Card.Financing);
            Assert.AreEqual(Brand.Visa, result.Card.Brand);
            Assert.AreEqual(new DateTime(2014, 10, 2, 7, 39, 50), result.Card.CreatedAt);
            Assert.False(result.Card.LiveMode);
            Assert.AreEqual("/charges/123", result.Location);
        }

        [Test]
        public void TestCreateChargeWithCustomerDefaultCard()
        {
            var charge = new ChargeCreateInfo();
            charge.Amount = 10000;//100 THB,=> 10000 Satangs
            charge.Currency = "THB";
            charge.Description = "Test charge";
            charge.ReturnUri = "http://localhost:3000/";
            charge.Capture = true;
            charge.CustomerId = "123";
            stubResponse(@"{
					    'object': 'charge',
					    'id': '123',
					    'livemode': false,
					    'location': '/charges/123',
					    'amount': 10000,
					    'currency': 'thb',
					    'description': 'test charge',
					    'capture': true,
					    'authorized': false,
					    'captured': false,
					    'transaction': null,
					    'return_uri': 'http://www.lvh.me:3000/?payment-result=success',
					    'reference': '123',
					    'authorize_uri': 'http://api.lvh.me:3000/payments/123/authorize',
					    'card': {
					        'object': 'card',
					        'id': '123',
					        'livemode': false,
					        'location': '/customers/123/cards/123',
					        'country': '',
					        'city': null,
					        'postal_code': null,
					        'financing': '',
					        'last_digits': '4242',
					        'brand': 'Visa',
					        'expiration_month': 9,
					        'expiration_year': 2017,
					        'fingerprint': '123',
					        'name': 'test card',
					        'created': '2014-10-02T05:25:10Z'
					    },
					    'customer': 'cust_test_4xl54swemkocy39ukvi',
					    'ip': null,
					    'created': '2014-10-02T07:53:10Z'
					}");
            var result = client.ChargeService.CreateCharge(charge);
            Assert.IsNotNull(result);
            Assert.AreEqual("123", result.Id);
            Assert.AreEqual(10000, result.Amount);
            Assert.AreEqual("thb", result.Currency);
            Assert.AreEqual(new DateTime(2014, 10, 2, 7, 53, 10), result.CreatedAt);
            Assert.IsNotNull(result.Card);
            Assert.AreEqual("4242", result.Card.LastDigits);
            Assert.AreEqual("test card", result.Card.Name);
            Assert.AreEqual(9, result.Card.ExpirationMonth);
            Assert.AreEqual(2017, result.Card.ExpirationYear);
            Assert.AreEqual("123", result.Card.Fingerprint);
            Assert.AreEqual("/customers/123/cards/123", result.Card.Location);
            Assert.IsNullOrEmpty(result.Card.Country);
            Assert.IsNullOrEmpty(result.Card.City);
            Assert.IsNullOrEmpty(result.Card.PostalCode);
            Assert.IsNullOrEmpty(result.Card.Financing);
            Assert.AreEqual(Brand.Visa, result.Card.Brand);
            Assert.AreEqual(new DateTime(2014, 10, 2, 5, 25, 10), result.Card.CreatedAt);
            Assert.False(result.Card.LiveMode);
            Assert.AreEqual("/charges/123", result.Location);
        }

        [Test]
        public void TestUpdateCharge()
        {
            var chargeUpdateInfo = new ChargeUpdateInfo();
            chargeUpdateInfo.Id = "123";
            chargeUpdateInfo.Description = "Test update description";

            stubResponse(@"{
					    'object': 'charge',
					    'id': '123',
					    'livemode': false,
					    'location': '/charges/123',
					    'amount': 10000,
					    'currency': 'thb',
					    'description': 'Test update description',
					    'capture': true,
					    'authorized': false,
					    'captured': false,
					    'transaction': null,
					    'return_uri': 'http://www.lvh.me:3000/?payment-result=success',
					    'reference': '123',
					    'authorize_uri': 'http://api.lvh.me:3000/payments/123/authorize',
					    'card': {
					        'object': 'card',
					        'id': '123',
					        'livemode': false,
					        'country': '',
					        'city': null,
					        'postal_code': null,
					        'financing': '',
					        'last_digits': '4242',
					        'brand': 'Visa',
					        'expiration_month': 9,
					        'expiration_year': 2017,
					        'fingerprint': '123',
					        'name': 'test card',
					        'created': '2014-10-02T08:08:11Z'
					    },
					    'customer': null,
					    'ip': null,
					    'created': '2014-10-02T08:08:11Z'
					}");

            var updateResult = client.ChargeService.UpdateCharge(chargeUpdateInfo);
            Assert.IsNotNull(updateResult);
            Assert.AreEqual("Test update description", updateResult.Description);
            Assert.AreEqual("123", updateResult.Id);
            Assert.AreEqual(10000, updateResult.Amount);
            Assert.AreEqual("thb", updateResult.Currency);
            Assert.AreEqual(new DateTime(2014, 10, 2, 8, 8, 11), updateResult.CreatedAt);
            Assert.IsNotNull(updateResult.Card);
            Assert.AreEqual("4242", updateResult.Card.LastDigits);
            Assert.AreEqual("test card", updateResult.Card.Name);
            Assert.AreEqual(9, updateResult.Card.ExpirationMonth);
            Assert.AreEqual(2017, updateResult.Card.ExpirationYear);
            Assert.AreEqual("123", updateResult.Card.Fingerprint);
            Assert.IsNull(updateResult.Card.Location);
            Assert.IsNullOrEmpty(updateResult.Card.Country);
            Assert.IsNullOrEmpty(updateResult.Card.City);
            Assert.IsNullOrEmpty(updateResult.Card.PostalCode);
            Assert.IsNullOrEmpty(updateResult.Card.Financing);
            Assert.AreEqual(Brand.Visa, updateResult.Card.Brand);
            Assert.AreEqual(new DateTime(2014, 10, 2, 8, 8, 11), updateResult.Card.CreatedAt);
            Assert.False(updateResult.Card.LiveMode);
            Assert.AreEqual("/charges/123", updateResult.Location);
        }

        [Test]
        public void TestCreateInvalidChargeAmount()
        {
            var charge = new ChargeCreateInfo();
            charge.Amount = -1;
            charge.Currency = "THB";
            charge.Description = "Test charge";
            charge.ReturnUri = "http://localhost:3000/";
            charge.Capture = true;
            charge.CardId = "123";
            Assert.Throws<InvalidChargeException>(delegate
                {
                    client.ChargeService.CreateCharge(charge);
                });
        }

        [Test]
        public void TestCreateInvalidCurrencyCharge()
        {
            var charge = new ChargeCreateInfo();
            charge.Amount = 10000000;
            charge.Currency = "THBs";
            charge.Description = "Test charge";
            charge.ReturnUri = "http://localhost:3000/";
            charge.Capture = true;
            charge.CardId = "123";
            stubException(new ApiException());
            Assert.Throws<ApiException>(delegate
                {
                    client.ChargeService.CreateCharge(charge);
                });
        }

        [Test]
        public void TestCreateZeroRefund()
        {
            Assert.Throws<ArgumentException>(delegate
                {
                    client.ChargeService.CreateRefund("chrg_test_4ypu0hc0ubm3sujb1g6", 0);
                });
        }

        [Test]
        public void TestCreateRefund()
        {
            stubResponse(@"{
                'object': 'refund',
                'id': 'rfnd_test_4ytdj6mfxqx6lqoyg50',
                'location': '/charges/chrg_test_4ypu0hc0ubm3sujb1g6/refunds/rfnd_test_4ytdj6mfxqx6lqoyg50',
                'amount': 100,
                'currency': 'thb',
                'charge': 'chrg_test_4ypu0hc0ubm3sujb1g6',
                'transaction': 'trxn_test_4ytdj6mmjdejo4yogx6',
                'created': '2015-01-23T07:34:04Z'
            }");

            var refund = client.ChargeService.CreateRefund("chrg_test_4ypu0hc0ubm3sujb1g6", 100);
            Assert.AreEqual(100, refund.Amount);
            Assert.AreEqual("thb", refund.Currency);
            Assert.AreEqual("chrg_test_4ypu0hc0ubm3sujb1g6", refund.ChargeId);
            Assert.AreEqual("trxn_test_4ytdj6mmjdejo4yogx6", refund.TransactionId);
            Assert.AreEqual("rfnd_test_4ytdj6mfxqx6lqoyg50", refund.Id);
        }

        public void TestGetRefund()
        {
            stubResponse(@"{
                'object': 'refund',
                'id': 'rfnd_test_4ytdj6mfxqx6lqoyg50',
                'location': '/charges/chrg_test_4ypu0hc0ubm3sujb1g6/refunds/rfnd_test_4ytdj6mfxqx6lqoyg50',
                'amount': 100,
                'currency': 'thb',
                'charge': 'chrg_test_4ypu0hc0ubm3sujb1g6',
                'transaction': 'trxn_test_4ytdj6mmjdejo4yogx6',
                'created': '2015-01-23T07:34:04Z'
            }");

            var refund = client.ChargeService.GetRefund("chrg_test_4ypu0hc0ubm3sujb1g6", "rfnd_test_4ytdj6mfxqx6lqoyg50");
            Assert.AreEqual(100, refund.Amount);
            Assert.AreEqual("thb", refund.Currency);
            Assert.AreEqual("chrg_test_4ypu0hc0ubm3sujb1g6", refund.ChargeId);
            Assert.AreEqual("trxn_test_4ytdj6mmjdejo4yogx6", refund.TransactionId);
            Assert.AreEqual("rfnd_test_4ytdj6mfxqx6lqoyg50", refund.Id);
        }

        public void TestGetRefunds()
        {
            stubResponse(@"{
                'object': 'list',
                'from': '1970-01-01T00:00:00+00:00',
                'to': '2015-01-23T08:00:04+00:00',
                'offset': 0,
                'limit': 20,
                'total': 1,
                'data': [
                    {
                        'object': 'refund',
                        'id': 'rfnd_test_4ytdj6mfxqx6lqoyg50',
                        'location': '/charges/chrg_test_4ypu0hc0ubm3sujb1g6/refunds/rfnd_test_4ytdj6mfxqx6lqoyg50',
                        'amount': 100,
                        'currency': 'thb',
                        'charge': 'chrg_test_4ypu0hc0ubm3sujb1g6',
                        'transaction': 'trxn_test_4ytdj6mmjdejo4yogx6',
                        'created': '2015-01-23T07:34:04Z'
                    }
                ],
                'location': '/charges/chrg_test_4ypu0hc0ubm3sujb1g6/refunds'
            }");


            var refunds = client.ChargeService.GetRefunds("chrg_test_4ypu0hc0ubm3sujb1g6");
            Assert.IsNotNull(refunds);
            Assert.AreEqual(20, refunds.Limit);
            Assert.AreEqual(0, refunds.Offset);
            Assert.AreEqual(1, refunds.Collection.Count);
            Assert.AreEqual("/charges/chrg_test_4ypu0hc0ubm3sujb1g6/refunds", refunds.Location);
        }
    }
}

