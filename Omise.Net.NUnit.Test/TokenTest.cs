using System;
using NUnit.Framework;

namespace Omise.Net.NUnit.Test
{
	[TestFixture]
	public class TokenTest: TestBase
	{
		[Test]
		public void TestCreateToken(){
			var card = new CardCreateInfo ();
			card.Name="TestCard";
			card.Number="4242424242424242";
			card.ExpirationMonth = 9;
			card.ExpirationYear=2017;

			var token = new TokenInfo ();
			token.Card = card;

			StubRequestWithResponse (@"{ 								    'object': 'token', 								    'id': '123', 								    'livemode': false, 								    'location': '/tokens/123', 								    'used': false, 								    'card': { 								        'object': 'card', 								        'livemode': false, 								        'country': '', 								        'city': null, 								        'postal_code': null, 								        'financing': '', 								        'last_digits': '4242', 								        'brand': 'Visa', 								        'expiration_month': 9, 								        'expiration_year': 2017, 								        'fingerprint': '123', 								        'name': 'TestCard', 								        'created': '2014-10-02T07:27:30Z' 								    }, 								    'created': '2014-10-02T07:27:30Z' 								} 								");
			var resultToken = client.TokenService.CreateToken (token);
			Assert.IsNotNull (resultToken);
			Assert.IsNotNull (resultToken.Id);
			Assert.IsFalse (resultToken.Used);
			Assert.IsNotNull (resultToken.Card);
			Assert.AreEqual ("TestCard", resultToken.Card.Name);
			Assert.AreEqual ("4242", resultToken.Card.LastDigits);
			Assert.AreEqual (9, resultToken.Card.ExpirationMonth);
			Assert.AreEqual (2017, resultToken.Card.ExpirationYear);
		}

		[Test]
		public void TestGetToken(){
			StubRequestWithResponse(@"{
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
			var resultShowToken = client.TokenService.GetToken ("123");
			Assert.IsNotNull (resultShowToken);
			Assert.IsNotNull (resultShowToken.Id);
			Assert.IsFalse (resultShowToken.Used);
			Assert.IsNotNull (resultShowToken.Card);
			Assert.AreEqual ("TestCard", resultShowToken.Card.Name);
			Assert.AreEqual ("4242", resultShowToken.Card.LastDigits);
			Assert.AreEqual (9, resultShowToken.Card.ExpirationMonth);
			Assert.AreEqual (2017, resultShowToken.Card.ExpirationYear);
		}
	}
}

