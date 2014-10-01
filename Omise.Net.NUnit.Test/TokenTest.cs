using System;
using NUnit.Framework;

namespace Omise.Net.NUnit.Test
{
	[TestFixture]
	public class TokenTest: TestBase
	{
		[Test]
		public void TestCreateToken(){
			var card = new CardInfo ();
			card.Name="TestCard";
			card.Number="4242424242424242";
			card.ExpirationMonth = "9";
			card.ExpirationYear="2017";

			var token = new TokenInfo ();
			token.Card = card;

			var resultToken = client.TokenService.CreateToken (token);
			Assert.IsNotNull (resultToken);
			Assert.IsNotNull (resultToken.Id);
			Assert.IsFalse (resultToken.Used);
			Assert.IsNotNull (resultToken.Card);
			Assert.AreEqual ("TestCard", resultToken.Card.Name);
			Assert.AreEqual ("4242", resultToken.Card.LastDigits);
			Assert.AreEqual ("9", resultToken.Card.ExpirationMonth);
			Assert.AreEqual ("2017", resultToken.Card.ExpirationYear);
		}

		[Test]
		public void TestGetToken(){
			var card = new CardInfo ();
			card.Name="TestCard";
			card.Number="4242424242424242";
			card.ExpirationMonth = "9";
			card.ExpirationYear="2017";

			var token = new TokenInfo ();
			token.Card = card;

			var resultToken = client.TokenService.CreateToken (token);
			var resultShowToken = client.TokenService.GetToken (resultToken.Id);
			Assert.IsNotNull (resultShowToken);
			Assert.IsNotNull (resultShowToken.Id);
			Assert.IsFalse (resultShowToken.Used);
			Assert.IsNotNull (resultShowToken.Card);
			Assert.AreEqual ("TestCard", resultShowToken.Card.Name);
			Assert.AreEqual ("4242", resultShowToken.Card.LastDigits);
			Assert.AreEqual ("9", resultShowToken.Card.ExpirationMonth);
			Assert.AreEqual ("2017", resultShowToken.Card.ExpirationYear);
		}
	}
}

