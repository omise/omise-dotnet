using System;
using NUnit.Framework;

namespace Omise.Net.NUnit.Test
{
    [TestFixture]
    public class TokenTest: TestBase
    {
        [Test]
        public void TestCreateToken()
        {
            var card = new CardCreateInfo();
            card.Name = "TestCard";
            card.Number = "4242424242424242";
            card.ExpirationMonth = 9;
            card.ExpirationYear = 2017;

            var token = new TokenInfo();
            token.Card = card;

            stubResponse(@"{
								    'object': 'token',
								    'id': '123',
								    'livemode': false,
								    'location': '/tokens/123',
								    'used': false,
								    'card': {
								        'object': 'card',
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
								        'name': 'TestCard',
								        'created': '2014-10-02T07:27:30Z'
								    },
								    'created': '2014-10-02T07:27:30Z'
								}
								");
            var resultToken = client.TokenService.CreateToken(token);
            Assert.IsNotNull(resultToken);
            Assert.AreEqual("123", resultToken.Id);
            Assert.IsFalse(resultToken.LiveMode);
            Assert.AreEqual("/tokens/123", resultToken.Location);
            Assert.IsFalse(resultToken.Used);
            Assert.IsNotNull(resultToken.Card);
            Assert.IsFalse(resultToken.Card.LiveMode);
            Assert.IsNullOrEmpty(resultToken.Card.Country);
            Assert.IsNullOrEmpty(resultToken.Card.City);
            Assert.IsNullOrEmpty(resultToken.Card.PostalCode);
            Assert.IsNullOrEmpty(resultToken.Card.Financing);
            Assert.AreEqual(Brand.Visa, resultToken.Card.Brand);
            Assert.AreEqual("123", resultToken.Card.Fingerprint);
            Assert.AreEqual("TestCard", resultToken.Card.Name);
            Assert.AreEqual("4242", resultToken.Card.LastDigits);
            Assert.AreEqual(9, resultToken.Card.ExpirationMonth);
            Assert.AreEqual(2017, resultToken.Card.ExpirationYear);
        }

        [Test]
        public void TestGetToken()
        {
            stubResponse(@"{
								    'object': 'token',
								    'id': '123',
								    'livemode': false,
								    'location': '/tokens/123',
								    'used': false,
								    'card': {
								        'object': 'card',
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
								        'name': 'TestCard',
								        'created': '2014-10-02T08:39:41Z'
								    },
								    'created': '2014-10-02T08:39:41Z'
								}");
            var resultShowToken = client.TokenService.GetToken("123");
            Assert.IsNotNull(resultShowToken);
            Assert.IsFalse(resultShowToken.LiveMode);
            Assert.AreEqual("/tokens/123", resultShowToken.Location);
            Assert.IsFalse(resultShowToken.Used);
            Assert.IsNotNull(resultShowToken.Card);
            Assert.IsFalse(resultShowToken.Card.LiveMode);
            Assert.IsNullOrEmpty(resultShowToken.Card.Country);
            Assert.IsNullOrEmpty(resultShowToken.Card.City);
            Assert.IsNullOrEmpty(resultShowToken.Card.PostalCode);
            Assert.IsNullOrEmpty(resultShowToken.Card.Financing);
            Assert.AreEqual(Brand.Visa, resultShowToken.Card.Brand);
            Assert.AreEqual("123", resultShowToken.Card.Fingerprint);
            Assert.AreEqual("TestCard", resultShowToken.Card.Name);
            Assert.AreEqual("4242", resultShowToken.Card.LastDigits);
            Assert.AreEqual(9, resultShowToken.Card.ExpirationMonth);
            Assert.AreEqual(2017, resultShowToken.Card.ExpirationYear);
        }
    }
}

