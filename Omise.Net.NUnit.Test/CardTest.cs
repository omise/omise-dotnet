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
			StubRequestWithResponse (TestHelper.GetJson("AllCards.json"));
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

            //Stub for internal TokenService call
            StubRequestWithResponse("/tokens", "POST", @"{
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

            StubRequestWithResponse(string.Format("/customers/{0}/cards", customerId), "POST", @"{
				'object': 'card',
				'id': '123',
				'livemode': false,
				'location': '/customers/123/cards/123',
				'country': 'Thailand',
				'city': 'Bangkok',
				'postal_code': null,
				'financing': '',
				'last_digits': '4242',
				'brand': 'Visa',
				'expiration_month': 9,
				'expiration_year': 2017,
				'fingerprint': '123',
				'name': 'Test Card',
				'created': '2014-10-02T06:09:01Z'
				}");

			var result = client.CardService.CreateCard(customerId, card);
			Assert.AreEqual ("4242", result.LastDigits);
			Assert.AreEqual (card.ExpirationMonth, result.ExpirationMonth);
			Assert.AreEqual (card.ExpirationYear, result.ExpirationYear);
			Assert.AreEqual (card.Name, result.Name);
			Assert.AreEqual (Brand.Visa, result.Brand);
			Assert.AreEqual ("Bangkok", result.City);
			Assert.AreEqual ("Thailand", result.Country);
			Assert.AreEqual ("123", result.Fingerprint);
			Assert.AreEqual ("123", result.Id);
			Assert.AreEqual (new DateTime(2014, 10, 2, 6, 9, 1), result.CreatedAt);
		}

        [Test]
        public void TestCreateCardWithCardToken() {
            var card = new CardCreateInfo();
            card.Name = "Test Card";
            card.Number = "4242424242424242";
            card.ExpirationMonth = 9;
            card.ExpirationYear = 2017;

            var token = new TokenInfo();
            token.Card = card;

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
								        'created': '2014-10-02T07:27:30Z'
								    },
								    'created': '2014-10-02T07:27:30Z'
								}
								");
            var resultToken = client.TokenService.CreateToken(token);

            StubRequestWithResponse(@"{
				'object': 'card',
				'id': '123',
				'livemode': false,
				'location': '/customers/123/cards/123',
				'country': 'Thailand',
				'city': 'Bangkok',
				'postal_code': null,
				'financing': '',
				'last_digits': '4242',
				'brand': 'Visa',
				'expiration_month': 9,
				'expiration_year': 2017,
				'fingerprint': '123',
				'name': 'Test Card',
				'created': '2014-10-02T06:09:01Z'
				}");

            var result = client.CardService.CreateCard(customerId, resultToken.Id);
            Assert.AreEqual("4242", result.LastDigits);
            Assert.AreEqual(card.ExpirationMonth, result.ExpirationMonth);
            Assert.AreEqual(card.ExpirationYear, result.ExpirationYear);
            Assert.AreEqual(card.Name, result.Name);
            Assert.AreEqual(Brand.Visa, result.Brand);
            Assert.AreEqual("Bangkok", result.City);
            Assert.AreEqual("Thailand", result.Country);
            Assert.AreEqual("123", result.Fingerprint);
            Assert.AreEqual("123", result.Id);
            Assert.AreEqual(new DateTime(2014, 10, 2, 6, 9, 1), result.CreatedAt);
        }

		[Test]
		public void TestCreateInvalidCardNumber(){
			var card = new CardCreateInfo ();
			card.ExpirationMonth = 9;
			card.ExpirationYear = 2017;
			card.Number = "42424242424242";
			card.Name = "Test card";
			StubExceptionThrow (new ApiException ());
			Assert.Throws<ApiException>(delegate { client.CardService.CreateCard ("123", card); } );
		}

		[Test]
		public void TestCreateInvalidCardExpirationMonth(){
			var card = new CardCreateInfo ();
			card.ExpirationMonth = 99;
			card.ExpirationYear = 2017;
			card.Number = "4242424242424242";
			card.Name = "Test card";

			Assert.Throws<InvalidCardException>(delegate { client.CardService.CreateCard ("123", card); } );

			card.ExpirationMonth = -10;
			Assert.Throws<InvalidCardException>(delegate { client.CardService.CreateCard ("123", card);} );
		}

		[Test]
		public void TestCreateInvalidCardExpirationYear(){
			var card = new CardCreateInfo ();
			card.ExpirationMonth = 1;
			card.ExpirationYear = 9999;
			card.Number = "4242424242424242";
			card.Name = "Test card";
			Assert.Throws<InvalidCardException>(delegate { client.CardService.CreateCard ("123", card); } );
		}

		[Test]
		public void TestUpdateCard(){
			var card = new CardCreateInfo ();
			card.Id = "123";
			card.Name="My Test Card";
			card.Number = "4242424242424242";
			card.ExpirationMonth=10;
			card.ExpirationYear=2018;

			StubRequestWithResponse (@"{
						    'object': 'card',
						    'id': '123',
						    'livemode': false,
						    'location': '/customers/123/cards/123',
						    'country': 'Thailand',
						    'city': 'Bangkok',
						    'postal_code': null,
						    'financing': '',
						    'last_digits': '4242',
						    'brand': 'Visa',
						    'expiration_month': 9,
						    'expiration_year': 2017,
						    'fingerprint': '123',
						    'name': 'My Test Card',
						    'created': '2014-10-02T05:25:10Z'
						}");
			var updateResult = client.CardService.UpdateCard (customerId, card);
			Assert.IsNotNull (updateResult);
			Assert.AreEqual ("4242", updateResult.LastDigits);
			Assert.AreEqual ("My Test Card", updateResult.Name);
			Assert.AreEqual (9, updateResult.ExpirationMonth);
			Assert.AreEqual (2017, updateResult.ExpirationYear);
			Assert.AreEqual ("123", updateResult.Fingerprint);
			Assert.AreEqual ("/customers/123/cards/123", updateResult.Location);
			Assert.AreEqual ("Thailand", updateResult.Country);
			Assert.AreEqual ("Bangkok", updateResult.City);
			Assert.IsNull (updateResult.PostalCode);
			Assert.IsNullOrEmpty (updateResult.Financing);
			Assert.AreEqual (Brand.Visa, updateResult.Brand);
			Assert.AreEqual (new DateTime (2014, 10, 2, 5, 25, 10), updateResult.CreatedAt);
			Assert.False (updateResult.LiveMode);
		}

		[Test]
		public void TestGetCard()
        {
			StubRequestWithResponse (@"{
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
				}");

			var getCardResult = client.CardService.GetCard (customerId, "123");
			Assert.IsNotNull (getCardResult);
			Assert.AreEqual ("4242", getCardResult.LastDigits);
			Assert.AreEqual ("Test Card", getCardResult.Name);
			Assert.AreEqual (9, getCardResult.ExpirationMonth);
			Assert.AreEqual (2017, getCardResult.ExpirationYear);
			Assert.AreEqual ("123", getCardResult.Fingerprint);
			Assert.AreEqual ("/customers/123/cards/123", getCardResult.Location);
			Assert.IsNullOrEmpty (getCardResult.Country);
			Assert.IsNullOrEmpty (getCardResult.City);
			Assert.IsNull (getCardResult.PostalCode);
			Assert.IsNullOrEmpty (getCardResult.Financing);
			Assert.AreEqual (Brand.Visa, getCardResult.Brand);
			Assert.AreEqual (new DateTime (2014, 10, 2, 6, 9, 1), getCardResult.CreatedAt);
			Assert.False (getCardResult.LiveMode);
		}

		[Test]
		public void TestDeleteCard()
        {
			StubRequestWithResponse (@"{
    					'object': 'card',
					    'id': '123',
					    'livemode': false,
					    'deleted': true
						}");
			var deleteResult = client.CardService.DeleteCard (customerId, "123");

			Assert.AreEqual ("card", deleteResult.ObjectType);
			Assert.AreEqual ("123", deleteResult.Id);
			Assert.IsFalse (deleteResult.LiveMode);
			Assert.IsTrue (deleteResult.Deleted);

			StubExceptionThrow (new ApiException());
			Assert.Throws<ApiException> (delegate {
				client.CardService.GetCard (customerId, "123");
			});
		}
	}
}

