using System;
using NUnit.Framework;

namespace Omise.Net.NUnit.Test
{
	[TestFixture]
	public class CardTest:TestBase
	{
		private string customerId;

		[SetUp]
		public override void Setup(){
			base.Setup ();
			var customerInfo = new CustomerInfo ();
			customerInfo.Email = "test1@localhost";
			var customerResult = client.CustomerService.CreateCustomer (customerInfo);
			customerId = customerResult.Id;
		}

		[TearDown]
		public override void Teardown(){
			client.CustomerService.DeleteCustomer (customerId);
			client = null;
		}

		[Test]
		public void TestGetAllCards(){
			var card = new CardInfo ();
			card.Name="Test Card";
			card.Number = "4242424242424242";
			card.ExpirationMonth="9";
			card.ExpirationYear="2017";

			client.CardService.CreateCard (customerId, card);

			var cards = client.CardService.GetAllCards (customerId, DateTime.Now.AddDays(-5), null, 0, 20);
			Assert.IsNotNull (cards);
			Assert.AreEqual(20, cards.Limit);
			Assert.AreEqual(0, cards.Offset);
			Assert.AreEqual(1, cards.Collection.Count);
		}

		[Test]
		public void TestCreateCard(){
			var card = new CardInfo ();
			card.Name="Test Card";
			card.Number = "4242424242424242";
			card.ExpirationMonth="9";
			card.ExpirationYear="2017";

			var result = client.CardService.CreateCard (customerId, card);
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
			Assert.IsNotNull (result.UpdatedAt);
		}

		[Test]
		public void TestGetCard(){
			var card = new CardInfo ();
			card.Name="Test Card";
			card.Number = "4242424242424242";
			card.ExpirationMonth="9";
			card.ExpirationYear="2017";

			var createResult = client.CardService.CreateCard (customerId, card);
			var getCardResult = client.CardService.GetCard (customerId, createResult.Id);
			Assert.IsNotNull (getCardResult);
			Assert.AreEqual ("4242", getCardResult.LastDigits);
			Assert.AreEqual ("Test Card", getCardResult.Name);
			Assert.AreEqual ("9", getCardResult.ExpirationMonth);
			Assert.AreEqual ("2017", getCardResult.ExpirationYear);
			Assert.IsNotNullOrEmpty (getCardResult.Fingerprint);
		}

		[Test]
		public void TestDeleteCard(){
			var card = new CardInfo ();
			card.Name="Test Card";
			card.Number = "4242424242424242";
			card.ExpirationMonth="9";
			card.ExpirationYear="2017";

			var createResult = client.CardService.CreateCard (customerId, card);
			client.CardService.DeleteCard (customerId, createResult.Id);
			Assert.Throws<ApiException>(delegate { client.CardService.GetCard (customerId, createResult.Id); } );
		}
	}
}

