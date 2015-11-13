using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Omise.Net.NUnit.Test
{
    [TestFixture]
    public class CardTest:TestBase
    {
        private const string customerId = "cust_test_1";
        [Test]
        public void TestGetAllCards()
        {
            stubResponse(TestHelper.GetJson("AllCards.json"));
            var cards = client.CardService.GetAllCards(customerId, DateTime.Now.AddDays(-5), null, 0, 20);
            Assert.IsNotNull(cards);
            Assert.AreEqual(20, cards.Limit);
            Assert.AreEqual(0, cards.Offset);
            Assert.AreEqual(2, cards.Collection.Count);
        }

        [Test]
        public void TestCreateCard()
        {
            var card = new CardCreateInfo();
            card.Name = "Test Card";
            card.Number = "4242424242424242";
            card.ExpirationMonth = 9;
            card.ExpirationYear = 2017;

            //Stub for internal TokenService call
            stubResponse("/tokens", "POST",
                @"{
                            'object': 'token',
                            'id': 'tokn_test_4yw4c9fa79ebj9ajisj',
                            'livemode': false,
                            'location': '/tokens/tokn_test_4yw4c9fa79ebj9ajisj',
                            'used': false,
                            'card': {
                                'object': 'card',
                                'id': 'card_test_122',
                                'livemode': false,
                                'country': 'us',
                                'city': null,
                                'postal_code': null,
                                'financing': '',
                                'bank': 'TEST BANK',
                                'last_digits': '4242',
                                'brand': 'Visa',
                                'expiration_month': 9,
                                'expiration_year': 2017,
                                'fingerprint': '122',
                                'name': 'Test Card',
                                'security_code_check': true,
                                'created': '2014-12-15T08:10:04Z'
                            },
                            'created': '2014-12-15T08:10:04Z'
                        }");

            stubResponse(@"{
                'object': 'customer',
                'id': 'cust_test_1',
                'livemode': false,
                'location': '/customers/cust_test_1',
                'default_card': 'card_test_122',
                'email': '',
                'description': 'Test customer',
                'created': '2014-12-15T08:10:23Z',
                'cards': {
                    'object': 'list',
                    'from': '1970-01-01T00:00:00+00:00',
                    'to': '2015-01-30T08:01:21+00:00',
                    'offset': 0,
                    'limit': 20,
                    'total': 1,
                    'data': [
                        {
                            'object': 'card',
                            'id': 'card_test_122',
                            'livemode': false,
                            'location': '/customers/cust_test_1/cards/card_test_122',
                            'country': 'us',
                            'city': null,
                            'postal_code': null,
                            'financing': '',
                            'bank': 'TEST BANK',
                            'last_digits': '4242',
                            'brand': 'Visa',
                            'expiration_month': 9,
                            'expiration_year': 2017,
                            'fingerprint': '122',
                            'name': 'Test Card',
                            'security_code_check': true,
                            'created': '2014-12-15T08:10:04Z'
                        }
                    ],
                    'location': '/customers/cust_test_1/cards'
                }
            }");

            stubResponse(@"{
                            'object': 'card',
                            'id': 'card_test_122',
                            'livemode': false,
                            'location': '/customers/cust_test_1/cards/card_test_122',
                            'country': 'us',
                            'city': null,
                            'postal_code': null,
                            'financing': '',
                            'bank': 'TEST BANK',
                            'last_digits': '4242',
                            'brand': 'Visa',
                            'expiration_month': 9,
                            'expiration_year': 2017,
                            'fingerprint': '122',
                            'name': 'Test Card',
                            'security_code_check': true,
                            'created': '2014-12-15T08:10:04Z'
                           }");

            var result = client.CardService.CreateCard(customerId, card);
            Assert.AreEqual("4242", result.LastDigits);
            Assert.AreEqual(card.ExpirationMonth, result.ExpirationMonth);
            Assert.AreEqual(card.ExpirationYear, result.ExpirationYear);
            Assert.AreEqual(card.Name, result.Name);
            Assert.AreEqual(Brand.Visa, result.Brand);
            Assert.IsNull(result.City);
            Assert.AreEqual("us", result.Country);
            Assert.AreEqual("122", result.Fingerprint);
            Assert.AreEqual("card_test_122", result.Id);
            Assert.AreEqual("/customers/cust_test_1/cards/card_test_122", result.Location);
            Assert.AreEqual(new DateTime(2014, 12, 15, 8, 10, 4), result.CreatedAt);
            Assert.AreEqual("TEST BANK", result.Bank);
        }

        [Test]
        public void TestCreateCardWithCardToken()
        {
            var card = new CardCreateInfo();
            card.Name = "Test new card";
            card.Number = "4111111111111111";
            card.ExpirationMonth = 12;
            card.ExpirationYear = 2019;

            var token = new TokenInfo();
            token.Card = card;

            stubResponse(@"{
                            'object': 'token',
                            'id': 'tokn_test_4ze5rxwk038n0wiet1e',
                            'livemode': false,
                            'location': '/tokens/tokn_test_4ze5rxwk038n0wiet1e',
                            'used': false,
                            'card': {
                                'object': 'card',
                                'id': 'card_test_123',
                                'livemode': false,
                                'country': 'us',
                                'city': null,
                                'postal_code': null,
                                'financing': '',
                                'bank': 'TEST BANK',
                                'last_digits': '1111',
                                'brand': 'Visa',
                                'expiration_month': 12,
                                'expiration_year': 2019,
                                'fingerprint': '123',
                                'name': 'Test new card',
                                'security_code_check': true,
                                'created': '2015-01-30T07:58:52Z'
                            },
                            'created': '2015-01-30T07:58:52Z'
                        }");

            var resultToken = client.TokenService.CreateToken(token);

            stubResponse("/tokens/" + resultToken.Id, "GET", @"{
                            'object': 'token',
                            'id': 'tokn_test_4ze5rxwk038n0wiet1e',
                            'livemode': false,
                            'location': '/tokens/tokn_test_4ze5rxwk038n0wiet1e',
                            'used': false,
                            'card': {
                                'object': 'card',
                                'id': 'card_test_123',
                                'livemode': false,
                                'country': 'us',
                                'city': null,
                                'postal_code': null,
                                'financing': '',
                                'bank': 'TEST BANK',
                                'last_digits': '1111',
                                'brand': 'Visa',
                                'expiration_month': 12,
                                'expiration_year': 2019,
                                'fingerprint': '123',
                                'name': 'Test new card',
                                'security_code_check': true,
                                'created': '2015-01-30T07:58:52Z'
                            },
                            'created': '2015-01-30T07:58:52Z'
                        }");

            stubResponse(@"{
                'object': 'customer',
                'id': 'cust_test_1',
                'livemode': false,
                'location': '/customers/cust_test_1',
                'default_card': 'card_test_122',
                'email': '',
                'description': 'Test customer',
                'created': '2014-12-15T08:10:23Z',
                'cards': {
                    'object': 'list',
                    'from': '1970-01-01T00:00:00+00:00',
                    'to': '2015-01-30T08:01:21+00:00',
                    'offset': 0,
                    'limit': 20,
                    'total': 2,
                    'data': [
                        {
                            'object': 'card',
                            'id': 'card_test_122',
                            'livemode': false,
                            'location': '/customers/cust_test_1/cards/card_test_122',
                            'country': 'us',
                            'city': null,
                            'postal_code': null,
                            'financing': '',
                            'bank': 'TEST BANK',
                            'last_digits': '4242',
                            'brand': 'Visa',
                            'expiration_month': 9,
                            'expiration_year': 2017,
                            'fingerprint': '122',
                            'name': 'Test',
                            'security_code_check': true,
                            'created': '2014-12-15T08:10:04Z'
                        },
                        {
                            'object': 'card',
                            'id': 'card_test_123',
                            'livemode': false,
                            'location': '/customers/cust_test_1/cards/card_test_123',
                            'country': 'us',
                            'city': null,
                            'postal_code': null,
                            'financing': '',
                            'bank': 'TEST BANK',
                            'last_digits': '1111',
                            'brand': 'Visa',
                            'expiration_month': 12,
                            'expiration_year': 2019,
                            'fingerprint': '123',
                            'name': 'Test new card',
                            'security_code_check': true,
                            'created': '2015-01-30T07:58:52Z'
                        }
                    ],
                    'location': '/customers/cust_test_1/cards'
                }
            }");

            stubResponse(@"{
                            'object': 'card',
                            'id': 'card_test_123',
                            'livemode': false,
                            'location': '/customers/cust_test_1/cards/card_test_123',
                            'country': 'us',
                            'city': null,
                            'postal_code': null,
                            'financing': '',
                            'bank': 'TEST BANK',    
                            'last_digits': '1111',
                            'brand': 'Visa',
                            'expiration_month': 12,
                            'expiration_year': 2019,
                            'fingerprint': '123',
                            'name': 'Test new card',
                            'security_code_check': true,
                            'created': '2015-01-30T07:58:52Z'
                           }");

            var result = client.CardService.CreateCard(customerId, resultToken.Id);
            Assert.AreEqual("1111", result.LastDigits);
            Assert.AreEqual(card.ExpirationMonth, result.ExpirationMonth);
            Assert.AreEqual(card.ExpirationYear, result.ExpirationYear);
            Assert.AreEqual(card.Name, result.Name);
            Assert.AreEqual(Brand.Visa, result.Brand);
            Assert.IsNull(result.City);
            Assert.AreEqual("us", result.Country);
            Assert.AreEqual("123", result.Fingerprint);
            Assert.AreEqual("card_test_123", result.Id);
            Assert.AreEqual("/customers/cust_test_1/cards/card_test_123", result.Location);
            Assert.AreEqual(new DateTime(2015, 1, 30, 7, 58, 52), result.CreatedAt);
            Assert.AreEqual("TEST BANK", result.Bank);
        }

        [Test]
        public void TestCreateInvalidCardNumber()
        {
            var card = new CardCreateInfo();
            card.ExpirationMonth = 9;
            card.ExpirationYear = 2017;
            card.Number = "42424242424242";
            card.Name = "Test card";
            stubException(new ApiException());
            Assert.Throws<ApiException>(delegate
                {
                    client.CardService.CreateCard(customerId, card);
                });
        }

        [Test]
        public void TestCreateInvalidCardExpirationMonth()
        {
            var card = new CardCreateInfo();
            card.ExpirationMonth = 99;
            card.ExpirationYear = 2017;
            card.Number = "4242424242424242";
            card.Name = "Test card";

            Assert.Throws<InvalidCardException>(delegate
                {
                    client.CardService.CreateCard(customerId, card);
                });

            card.ExpirationMonth = -10;
            Assert.Throws<InvalidCardException>(delegate
                {
                    client.CardService.CreateCard(customerId, card);
                });
        }

        [Test]
        public void TestCreateInvalidCardExpirationYear()
        {
            var card = new CardCreateInfo();
            card.ExpirationMonth = 1;
            card.ExpirationYear = 9999;
            card.Number = "4242424242424242";
            card.Name = "Test card";
            Assert.Throws<InvalidCardException>(delegate
                {
                    client.CardService.CreateCard(customerId, card);
                });
        }

        [Test]
        public void TestUpdateCard()
        {
            var card = new CardUpdateInfo();
            card.Id = "123";
            card.Name = "My Test Card";
            card.Number = "4242424242424242";
            card.ExpirationMonth = 9;
            card.ExpirationYear = 2017;

            stubResponse(@"{
                            'object': 'card',
                            'id': '123',
                            'livemode': false,
                            'location': '/customers/cust_test_1/cards/123',
                            'country': 'Thailand',
                            'city': 'Bangkok',
                            'postal_code': null,
                            'financing': '',
                            'bank': 'TEST BANK',
                            'last_digits': '4242',
                            'brand': 'Visa',
                            'expiration_month': 9,
                            'expiration_year': 2017,
                            'fingerprint': '123',
                            'name': 'My Test Card',
                            'security_code_check': true,
                            'created': '2014-10-02T05:25:10Z'
                           }");
            var result = client.CardService.UpdateCard(customerId, card);
            Assert.IsNotNull(result);
            Assert.AreEqual("4242", result.LastDigits);
            Assert.AreEqual("My Test Card", result.Name);
            Assert.AreEqual(9, result.ExpirationMonth);
            Assert.AreEqual(2017, result.ExpirationYear);
            Assert.AreEqual("123", result.Fingerprint);
            Assert.AreEqual("/customers/cust_test_1/cards/123", result.Location);
            Assert.AreEqual("Thailand", result.Country);
            Assert.AreEqual("Bangkok", result.City);
            Assert.IsNull(result.PostalCode);
            Assert.IsNullOrEmpty(result.Financing);
            Assert.AreEqual(Brand.Visa, result.Brand);
            Assert.AreEqual(new DateTime(2014, 10, 2, 5, 25, 10), result.CreatedAt);
            Assert.False(result.LiveMode);
            Assert.AreEqual("TEST BANK", result.Bank);
        }

        [Test]
        public void TestGetCard()
        {
            stubResponse(@"{
                            'object': 'card',
                            'id': '123',
                            'livemode': false,
                            'location': '/customers/cust_test_1/cards/123',
                            'country': '',
                            'city': null,
                            'postal_code': null,
                            'financing': '',
                            'bank': 'TEST BANK',
                            'last_digits': '4242',
                            'brand': 'Visa',
                            'expiration_month': 9,
                            'expiration_year': 2017,
                            'fingerprint': '123',
                            'name': 'Test Card',
                            'security_code_check': true,
                            'created': '2014-10-02T06:09:01Z'
                           }");

            var result = client.CardService.GetCard(customerId, "123");
            Assert.IsNotNull(result);
            Assert.AreEqual("4242", result.LastDigits);
            Assert.AreEqual("Test Card", result.Name);
            Assert.AreEqual(9, result.ExpirationMonth);
            Assert.AreEqual(2017, result.ExpirationYear);
            Assert.AreEqual("123", result.Fingerprint);
            Assert.AreEqual("/customers/cust_test_1/cards/123", result.Location);
            Assert.IsNullOrEmpty(result.Country);
            Assert.IsNullOrEmpty(result.City);
            Assert.IsNull(result.PostalCode);
            Assert.IsNullOrEmpty(result.Financing);
            Assert.AreEqual(Brand.Visa, result.Brand);
            Assert.AreEqual(new DateTime(2014, 10, 2, 6, 9, 1), result.CreatedAt);
            Assert.False(result.LiveMode);
            Assert.AreEqual("TEST BANK", result.Bank);
        }

        [Test]
        public void TestDeleteCard()
        {
            stubResponse(@"{
                            'object': 'card',
                            'id': '123',
                            'livemode': false,
                            'deleted': true
                           }");
            var result = client.CardService.DeleteCard(customerId, "123");

            Assert.AreEqual("123", result.Id);
            Assert.IsFalse(result.LiveMode);
            Assert.IsTrue(result.Deleted);
        }
    }
}

