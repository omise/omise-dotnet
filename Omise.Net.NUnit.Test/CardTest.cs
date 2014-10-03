using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Omise.Net.NUnit.Test
{
	[TestFixture]
	public class CardTest:TestBase
	{
		private string customerId = "123";

		[Test]
		public void TestGetAllCards(){
			StubRequestWithResponse (TestHelper.GetJson("AllCards"));
			var cards = client.CardService.GetAllCards (customerId, DateTime.Now.AddDays(-5), null, 0, 20);
			Assert.IsNotNull (cards);
			Assert.AreEqual(20, cards.Limit);
			Assert.AreEqual(0, cards.Offset);
			Assert.AreEqual(2, cards.Collection.Count);
		}

		[Test]
		public void TestCreateCard(){
			var card = new CardCreateInfo ();
			card.Name="Test Card";
			card.Number = "4242424242424242";
			card.ExpirationMonth=9;
			card.ExpirationYear=2017;

			string json = @"{
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
				'name': 'Test Card',
				'created': '2014-10-02T06:09:01Z'
				}";

			StubRequestWithResponse (json);
			var result = client.CardService.CreateCard(customerId, card);
			Assert.AreEqual ("4242", result.LastDigits);
			Assert.AreEqual (card.ExpirationMonth, result.ExpirationMonth);
			Assert.AreEqual (card.ExpirationYear, result.ExpirationYear);
			Assert.AreEqual (card.Name, result.Name);
			Assert.IsNotNull (result.Brand);
			Assert.IsNull (result.City);
			Assert.IsEmpty (result.Country);
			Assert.IsNotNullOrEmpty (result.Fingerprint);
			Assert.IsNotNull (result.Id);
			Assert.IsNotNull (result.CreatedAt);
		}

		[Test]
		public void TestUpdateCard(){
			var card = new CardCreateInfo ();
			card.Id = "123";
			card.Name="My Test Card";
			card.Number = "4242424242424242";
			card.ExpirationMonth=10;
			card.ExpirationYear=2018;

			string json = @"{
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
						    'name': 'My Test Card',
						    'created': '2014-10-02T05:25:10Z'
						}";

			StubRequestWithResponse (json);
			var updateResult = client.CardService.UpdateCard (customerId, card);
			Assert.IsNotNull (updateResult);
			Assert.AreEqual ("4242", updateResult.LastDigits);
			Assert.AreEqual ("My Test Card", updateResult.Name);
			Assert.AreEqual (9, updateResult.ExpirationMonth);
			Assert.AreEqual (2017, updateResult.ExpirationYear);
			Assert.IsNotNullOrEmpty (updateResult.Fingerprint);
		}

		[Test]
		public void TestGetCard(){
			string json = @"{
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
				'name': 'Test Card',
				'created': '2014-10-02T06:09:01Z'
				}";

			StubRequestWithResponse (json);
			var getCardResult = client.CardService.GetCard (customerId, "123");
			Assert.IsNotNull (getCardResult);
			Assert.AreEqual ("4242", getCardResult.LastDigits);
			Assert.AreEqual ("Test Card", getCardResult.Name);
			Assert.AreEqual (9, getCardResult.ExpirationMonth);
			Assert.AreEqual (2017, getCardResult.ExpirationYear);
			Assert.IsNotNullOrEmpty (getCardResult.Fingerprint);
		}

		[Test]
		public void TestDeleteCard(){
			var json = @"{
    					'object': 'card',
					    'id': '123',
					    'livemode': false,
					    'deleted': true
						}";

			StubRequestWithResponse (json);
			client.CardService.DeleteCard (customerId, "123");

			StubExceptionThrow (new ApiException());
			Assert.Throws<ApiException> (delegate {
				client.CardService.GetCard (customerId, "123");
			});
		}
	}
}

