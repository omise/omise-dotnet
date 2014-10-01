using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Omise.Net.NUnit.Test
{
	[TestFixture]
	public class ChargeTest:TestBase
	{
		[Test]
		public void TestChargeMountValidations(){
			var charge = new ChargeInfo ();
			Assert.False (charge.Valid);
			Assert.Contains(new KeyValuePair<string, string>("Amount", "must be greater than 0"), charge.Errors);
		}

		[Test]
		public void TestChargeCurrencyValidations(){
			var charge = new ChargeInfo ();
			charge.Amount = 10000;
			Assert.False (charge.Valid);
			Assert.Contains(new KeyValuePair<string, string>("Currency", "cannot be blank"), charge.Errors);
		}

		[Test]
		public void TestCreateCharge(){
			var charge = new ChargeInfo ();
			charge.Amount = 10000;//100 THB,=> 10000 Satangs
			charge.Currency = "THB";
			charge.Description = "Test charge";
			charge.ReturnUri = "http://localhost:3000/";
			charge.Capture = true;
			var card = new CardInfo ();
			card.ExpirationMonth = "09";
			card.ExpirationYear = "2017";
			card.Number = "4242424242424242";
			card.Name = "Test card";
			charge.Card = card;
			var result = client.ChargeService.CreateCharge (charge);
			Assert.IsNotNull (result);
			Assert.AreEqual (charge.Amount, result.Amount);
		}
		[Test]
		public void TestCreateChargeWithCardToken(){
			var card = new CardInfo ();
			card.Name="TestCard";
			card.Number="4242424242424242";
			card.ExpirationMonth = "9";
			card.ExpirationYear="2017";

			var token = new TokenInfo ();
			token.Card = card;

			var resultToken = client.TokenService.CreateToken (token);

			var charge = new ChargeInfo ();
			charge.Amount = 10000;//100 THB,=> 10000 Satangs
			charge.Currency = "THB";
			charge.Description = "Test charge";
			charge.ReturnUri = "http://localhost:3000/";
			charge.Capture = true;
			charge.CardId = resultToken.Id;
			var result = client.ChargeService.CreateCharge (charge);
			Assert.IsNotNull (result);
			Assert.AreEqual (charge.Amount, result.Amount);
		}

		[Test]
		public void TestCreateChargeWithCardId(){
			var customerInfo = new CustomerInfo ();
			customerInfo.Email = "test1@localhost";
			var customerResult = client.CustomerService.CreateCustomer (customerInfo);

			var card = new CardInfo ();
			card.Name="Test Card";
			card.Number = "4242424242424242";
			card.ExpirationMonth="9";
			card.ExpirationYear="2017";

			var cardResult = client.CardService.CreateCard (customerResult.Id, card);
			var charge = new ChargeInfo ();
			charge.Amount = 10000;//100 THB,=> 10000 Satangs
			charge.Currency = "THB";
			charge.Description = "Test charge";
			charge.ReturnUri = "http://localhost:3000/";
			charge.Capture = true;
			charge.CardId = cardResult.Id;
			charge.CustomerId = customerResult.Id;
			var result = client.ChargeService.CreateCharge (charge);
			Assert.IsNotNull (result);
			Assert.AreEqual (charge.Amount, result.Amount);
		}

		[Test]
		public void TestCreateChargeWithCustomerDefaultCard(){
			var customerInfo = new CustomerInfo ();
			customerInfo.Email = "test1@localhost";
			var customerResult = client.CustomerService.CreateCustomer (customerInfo);

			var card1 = new CardInfo ();
			card1.Name="Test Card";
			card1.Number = "4242424242424242";
			card1.ExpirationMonth="9";
			card1.ExpirationYear="2017";

			client.CardService.CreateCard (customerResult.Id, card1);

			var card2 = new CardInfo ();
			card2.Name="Test Card";
			card2.Number = "4242424242424242";
			card2.ExpirationMonth="10";
			card2.ExpirationYear="2018";

			client.CardService.CreateCard (customerResult.Id, card2);

			var charge = new ChargeInfo ();
			charge.Amount = 10000;//100 THB,=> 10000 Satangs
			charge.Currency = "THB";
			charge.Description = "Test charge";
			charge.ReturnUri = "http://localhost:3000/";
			charge.Capture = true;
			charge.CustomerId = customerResult.Id;
			var result = client.ChargeService.CreateCharge (charge);
			Assert.IsNotNull (result);
			Assert.AreEqual (charge.Amount, result.Amount);
			Assert.AreEqual("4242", result.Card.LastDigits);
		}

		[Test]
		public void TestUpdateCharge(){
			var charge = new ChargeInfo ();
			charge.Amount = 10000;//100 THB,=> 10000 Satangs
			charge.Currency = "THB";
			charge.Description = "Test charge";
			charge.ReturnUri = "http://localhost:3000/";
			charge.Capture = true;
			var card = new CardInfo ();
			card.ExpirationMonth = "09";
			card.ExpirationYear = "2017";
			card.Number = "4242424242424242";
			card.Name = "Test card";
			charge.Card = card;
			var result = client.ChargeService.CreateCharge (charge);
			Assert.IsNotNull (result);
			Assert.AreEqual (charge.Amount, result.Amount);

			var chargeUpdateInfo = new ChargeUpdateInfo();
			chargeUpdateInfo.Id = result.Id;
			chargeUpdateInfo.Description = "Test update description";
			var updateResult = client.ChargeService.UpdateCharge(chargeUpdateInfo);
			Assert.IsNotNull (updateResult);
			Assert.AreEqual ("Test update description", updateResult.Description);
		}

		[Test]
		public void TestCreateInvalidChargeAmount(){
			var charge = new ChargeInfo ();
			charge.Amount = -1;//100 THB,=> 10000 Satangs
			charge.Currency = "THB";
			charge.Description = "Test charge";
			charge.ReturnUri = "http://localhost:3000/";
			charge.Capture = true;
			var card = new CardInfo ();
			card.ExpirationMonth = "09";
			card.ExpirationYear = "2017";
			card.Number = "4242424242424242";
			card.Name = "Test card";
			charge.Card = card;
			Assert.Throws<InvalidChargeException>(delegate { client.ChargeService.CreateCharge (charge); } );
		}

		[Test]
		public void TestCreateInvalidCurrencyCharge(){
			var charge = new ChargeInfo ();
			charge.Amount = 10000000;//100 THB,=> 10000 Satangs
			charge.Currency = "THBs";
			charge.Description = "Test charge";
			charge.ReturnUri = "http://localhost:3000/";
			charge.Capture = true;
			var card = new CardInfo ();
			card.ExpirationMonth = "09";
			card.ExpirationYear = "2017";
			card.Number = "4242424242424242";
			card.Name = "Test card";
			charge.Card = card;
			Assert.Throws<ApiException>(delegate { client.ChargeService.CreateCharge (charge); } );
		}

		[Test]
		public void TestCreateInvalidChargeCardNumber(){
			var charge = new ChargeInfo ();
			charge.Amount = 1000;//100 THB,=> 10000 Satangs
			charge.Currency = "THB";
			charge.Description = "Test charge";
			charge.ReturnUri = "http://localhost:3000/";
			charge.Capture = true;
			var card = new CardInfo ();
			card.ExpirationMonth = "09";
			card.ExpirationYear = "2017";
			card.Number = "42424242424242";
			card.Name = "Test card";
			charge.Card = card;
			Assert.Throws<ApiException>(delegate { client.ChargeService.CreateCharge (charge); } );
		}

		[Test]
		public void TestCreateInvalidChargeCardExpirationMonth(){
			var charge = new ChargeInfo ();
			charge.Amount = 1000;//100 THB,=> 10000 Satangs
			charge.Currency = "THB";
			charge.Description = "Test charge";
			charge.ReturnUri = "http://localhost:3000/";
			charge.Capture = true;
			var card = new CardInfo ();
			card.ExpirationMonth = "99";
			card.ExpirationYear = "2017";
			card.Number = "4242424242424242";
			card.Name = "Test card";
			charge.Card = card;
			Assert.Throws<ApiException>(delegate { client.ChargeService.CreateCharge (charge); } );

			card.ExpirationMonth = "-10";
			Assert.Throws<ApiException>(delegate { client.ChargeService.CreateCharge (charge); } );
		}

		[Test]
		public void TestCreateInvalidChargeCardExpirationYear(){
			var charge = new ChargeInfo ();
			charge.Amount = 1000;//100 THB,=> 10000 Satangs
			charge.Currency = "THB";
			charge.Description = "Test charge";
			charge.ReturnUri = "http://localhost:3000/";
			charge.Capture = true;
			var card = new CardInfo ();
			card.ExpirationMonth = "01";
			card.ExpirationYear = "9999";
			card.Number = "4242424242424242";
			card.Name = "Test card";
			charge.Card = card;
			Assert.Throws<ApiException>(delegate { client.ChargeService.CreateCharge (charge); } );
		}

		[Test]
		public void TestUnreachableHost(){
			var charge = new ChargeInfo ();
			charge.Amount = 10000;//100 THB,=> 10000 Satangs
			charge.Currency = "THB";
			charge.Description = "Test charge";
			charge.ReturnUri = "http://localhost:3000/";
			charge.Capture = true;
			var card = new CardInfo ();
			card.ExpirationMonth = "09";
			card.ExpirationYear = "2017";
			card.Number = "4242424242424242";
			card.Name = "Test card";
			charge.Card = card;
			client = new Omise.Client(this.apiKey, "http://api.lvh.me:3001");
			Assert.Throws<ApiException>(delegate { client.ChargeService.CreateCharge (charge); } );
		}
	}
}

