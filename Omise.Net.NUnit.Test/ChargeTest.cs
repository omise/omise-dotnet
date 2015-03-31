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
            stubResponse(TestHelper.GetJson("ChargeWithRefund.json"));
            var result = client.ChargeService.GetCharge("chrg_test_4zgsgfb13gw8kwknmgy");

            Assert.AreEqual("chrg_test_4zgsgfb13gw8kwknmgy", result.Id);
            Assert.AreEqual(1000000, result.Amount);
            Assert.AreEqual("thb", result.Currency);
            Assert.IsTrue(result.Captured);
            Assert.AreEqual(new DateTime(2015, 3, 24, 4, 17, 31), result.CreatedAt);
            Assert.IsNotNull(result.Card);
            Assert.AreEqual("4242", result.Card.LastDigits);
            Assert.AreEqual("Test card", result.Card.Name);
            Assert.AreEqual(9, result.Card.ExpirationMonth);
            Assert.AreEqual(2017, result.Card.ExpirationYear);
            Assert.AreEqual("FK8mTeCO13cSIMMAGAm8BvoIiHPQgNpMuo+6s4VEI9U=", result.Card.Fingerprint);
            Assert.IsNull(result.Card.Location);
            Assert.IsNullOrEmpty(result.Card.Country);
            Assert.IsNullOrEmpty(result.Card.City);
            Assert.IsNullOrEmpty(result.Card.PostalCode);
            Assert.IsNullOrEmpty(result.Card.Financing);
            Assert.AreEqual(Brand.Visa, result.Card.Brand);
            Assert.AreEqual(new DateTime(2015, 3, 24, 4, 16, 31), result.Card.CreatedAt);
            Assert.False(result.Card.LiveMode);
            Assert.AreEqual("/charges/chrg_test_4zgsgfb13gw8kwknmgy", result.Location);
            Assert.AreEqual(100000, result.Refunded);
            Assert.IsNotNull(result.RefundCollection);
            Assert.AreEqual(1, result.RefundCollection.Total);
        }

        [Test]
        public void TestCreateChargeWithCardToken()
        {
            var charge = new ChargeCreateInfo();
            charge.Amount = 1000000;//10000 THB,=> 1000000 Satangs
            charge.Currency = "THB";
            charge.Description = "Test charge";
            charge.Capture = true;
            charge.CardId = "tokn_test_4zhmrbda6rup7dv02jm";

            stubResponse(TestHelper.GetJson("Charge.json"));
            var result = client.ChargeService.CreateCharge(charge);

            Assert.AreEqual("chrg_test_4zgsgfb13gw8kwknmgy", result.Id);
            Assert.AreEqual(1000000, result.Amount);
            Assert.AreEqual("thb", result.Currency);
            Assert.IsTrue(result.Captured);
            Assert.AreEqual(new DateTime(2015, 3, 24, 4, 17, 31), result.CreatedAt);
            Assert.IsNotNull(result.Card);
            Assert.AreEqual("4242", result.Card.LastDigits);
            Assert.AreEqual("Test card", result.Card.Name);
            Assert.AreEqual(9, result.Card.ExpirationMonth);
            Assert.AreEqual(2017, result.Card.ExpirationYear);
            Assert.AreEqual("FK8mTeCO13cSIMMAGAm8BvoIiHPQgNpMuo+6s4VEI9U=", result.Card.Fingerprint);
            Assert.IsNull(result.Card.Location);
            Assert.IsNullOrEmpty(result.Card.Country);
            Assert.IsNullOrEmpty(result.Card.City);
            Assert.IsNullOrEmpty(result.Card.PostalCode);
            Assert.IsNullOrEmpty(result.Card.Financing);
            Assert.AreEqual(Brand.Visa, result.Card.Brand);
            Assert.AreEqual(new DateTime(2015, 3, 24, 4, 16, 31), result.Card.CreatedAt);
            Assert.False(result.Card.LiveMode);
            Assert.AreEqual("/charges/chrg_test_4zgsgfb13gw8kwknmgy", result.Location);
            Assert.AreEqual(0, result.Refunded);
            Assert.AreEqual(0, result.RefundCollection.Total);
        }

        [Test]
        public void TestCreateChargeWithCardId()
        {   
            var charge = new ChargeCreateInfo();
            charge.Amount = 1000000;//10000 THB,=> 1000000 Satangs
            charge.Currency = "THB";
            charge.Description = "Test charge";
            charge.Capture = true;
            charge.CardId = "card_test_4zgsg2pxszbt70yjvlf";
            charge.CustomerId = "cust_test_4zh8gbb5hagc1dfiz4e";
            stubResponse(TestHelper.GetJson("Charge.json"));

            var result = client.ChargeService.CreateCharge(charge);

            Assert.AreEqual(1000000, result.Amount);
            Assert.AreEqual("thb", result.Currency);
            Assert.IsTrue(result.Captured);
            Assert.AreEqual(new DateTime(2015, 3, 24, 4, 17, 31), result.CreatedAt);
            Assert.IsNotNull(result.Card);
            Assert.AreEqual("4242", result.Card.LastDigits);
            Assert.AreEqual("Test card", result.Card.Name);
            Assert.AreEqual(9, result.Card.ExpirationMonth);
            Assert.AreEqual(2017, result.Card.ExpirationYear);
            Assert.AreEqual("FK8mTeCO13cSIMMAGAm8BvoIiHPQgNpMuo+6s4VEI9U=", result.Card.Fingerprint);
            Assert.IsNull(result.Card.Location);
            Assert.IsNullOrEmpty(result.Card.Country);
            Assert.IsNullOrEmpty(result.Card.City);
            Assert.IsNullOrEmpty(result.Card.PostalCode);
            Assert.IsNullOrEmpty(result.Card.Financing);
            Assert.AreEqual(Brand.Visa, result.Card.Brand);
            Assert.AreEqual(new DateTime(2015, 3, 24, 4, 16, 31), result.Card.CreatedAt);
            Assert.False(result.Card.LiveMode);
            Assert.AreEqual("/charges/chrg_test_4zgsgfb13gw8kwknmgy", result.Location);
            Assert.AreEqual(0, result.Refunded);
            Assert.AreEqual(0, result.RefundCollection.Total);
        }

        [Test]
        public void TestCreateChargeWithCustomerDefaultCard()
        {
            var charge = new ChargeCreateInfo();
            charge.Amount = 1000000;//10000 THB,=> 1000000 Satangs
            charge.Currency = "THB";
            charge.Description = "Test charge";
            charge.Capture = true;
            charge.CustomerId = "cust_test_4zh8gbb5hagc1dfiz4e";
            stubResponse(TestHelper.GetJson("Charge.json"));

            var result = client.ChargeService.CreateCharge(charge);
            Assert.AreEqual(1000000, result.Amount);
            Assert.AreEqual("thb", result.Currency);
            Assert.IsTrue(result.Captured);
            Assert.AreEqual(new DateTime(2015, 3, 24, 4, 17, 31), result.CreatedAt);
            Assert.IsNotNull(result.Card);
            Assert.AreEqual("4242", result.Card.LastDigits);
            Assert.AreEqual("Test card", result.Card.Name);
            Assert.AreEqual(9, result.Card.ExpirationMonth);
            Assert.AreEqual(2017, result.Card.ExpirationYear);
            Assert.AreEqual("FK8mTeCO13cSIMMAGAm8BvoIiHPQgNpMuo+6s4VEI9U=", result.Card.Fingerprint);
            Assert.IsNull(result.Card.Location);
            Assert.IsNullOrEmpty(result.Card.Country);
            Assert.IsNullOrEmpty(result.Card.City);
            Assert.IsNullOrEmpty(result.Card.PostalCode);
            Assert.IsNullOrEmpty(result.Card.Financing);
            Assert.AreEqual(Brand.Visa, result.Card.Brand);
            Assert.AreEqual(new DateTime(2015, 3, 24, 4, 16, 31), result.Card.CreatedAt);
            Assert.False(result.Card.LiveMode);
            Assert.AreEqual("/charges/chrg_test_4zgsgfb13gw8kwknmgy", result.Location);
            Assert.AreEqual(0, result.Refunded);
            Assert.AreEqual(0, result.RefundCollection.Total);
        }

        [Test]
        public void TestUpdateCharge()
        {
            var chargeUpdateInfo = new ChargeUpdateInfo();
            chargeUpdateInfo.Id = "chrg_test_4zgsgfb13gw8kwknmgy";
            chargeUpdateInfo.Description = "Test update description";

            stubResponse(TestHelper.GetJson("ChargeUpdated.json"));

            var updateResult = client.ChargeService.UpdateCharge(chargeUpdateInfo);

            Assert.AreEqual(1000000, updateResult.Amount);
            Assert.AreEqual("thb", updateResult.Currency);
            Assert.IsTrue(updateResult.Captured);
            Assert.AreEqual("Test update description", updateResult.Description);
            Assert.AreEqual(new DateTime(2015, 3, 24, 4, 17, 31), updateResult.CreatedAt);
            Assert.IsNotNull(updateResult.Card);
            Assert.AreEqual("4242", updateResult.Card.LastDigits);
            Assert.AreEqual("Test card", updateResult.Card.Name);
            Assert.AreEqual(9, updateResult.Card.ExpirationMonth);
            Assert.AreEqual(2017, updateResult.Card.ExpirationYear);
            Assert.AreEqual("FK8mTeCO13cSIMMAGAm8BvoIiHPQgNpMuo+6s4VEI9U=", updateResult.Card.Fingerprint);
            Assert.IsNull(updateResult.Card.Location);
            Assert.IsNullOrEmpty(updateResult.Card.Country);
            Assert.IsNullOrEmpty(updateResult.Card.City);
            Assert.IsNullOrEmpty(updateResult.Card.PostalCode);
            Assert.IsNullOrEmpty(updateResult.Card.Financing);
            Assert.AreEqual(Brand.Visa, updateResult.Card.Brand);
            Assert.AreEqual(new DateTime(2015, 3, 24, 4, 16, 31), updateResult.Card.CreatedAt);
            Assert.False(updateResult.Card.LiveMode);
            Assert.AreEqual("/charges/chrg_test_4zgsgfb13gw8kwknmgy", updateResult.Location);
            Assert.AreEqual(0, updateResult.Refunded);
            Assert.AreEqual(0, updateResult.RefundCollection.Total);
        }

        [Test]
        public void TestCreateInvalidChargeAmount()
        {
            var charge = new ChargeCreateInfo();
            charge.Amount = -1;
            charge.Currency = "THB";
            charge.Description = "Test charge";
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
                    client.ChargeService.CreateRefund("chrg_test_4zgsgfb13gw8kwknmgy", 0);
                });
        }

        [Test]
        public void TestCreateRefund()
        {
            stubResponse(@"{
                'object': 'refund',
                'id': 'rfnd_test_4ytdj6mfxqx6lqoyg50',
                'location': '/charges/chrg_test_4zgsgfb13gw8kwknmgy/refunds/rfnd_test_4ytdj6mfxqx6lqoyg50',
                'amount': 100,
                'currency': 'thb',
                'charge': 'chrg_test_4zgsgfb13gw8kwknmgy',
                'transaction': 'trxn_test_4ytdj6mmjdejo4yogx6',
                'created': '2015-01-23T07:34:04Z'
            }");

            var refund = client.ChargeService.CreateRefund("chrg_test_4zgsgfb13gw8kwknmgy", 100);
            Assert.AreEqual(100, refund.Amount);
            Assert.AreEqual("thb", refund.Currency);
            Assert.AreEqual("chrg_test_4zgsgfb13gw8kwknmgy", refund.ChargeId);
            Assert.AreEqual("trxn_test_4ytdj6mmjdejo4yogx6", refund.TransactionId);
            Assert.AreEqual("rfnd_test_4ytdj6mfxqx6lqoyg50", refund.Id);
            Assert.AreEqual(new DateTime(2015, 1, 23, 7, 34, 4), refund.CreatedAt);
        }

        public void TestGetRefund()
        {
            stubResponse(@"{
                'object': 'refund',
                'id': 'rfnd_test_4ytdj6mfxqx6lqoyg50',
                'location': '/charges/chrg_test_4zgsgfb13gw8kwknmgy/refunds/rfnd_test_4ytdj6mfxqx6lqoyg50',
                'amount': 100,
                'currency': 'thb',
                'charge': 'chrg_test_4zgsgfb13gw8kwknmgy',
                'transaction': 'trxn_test_4ytdj6mmjdejo4yogx6',
                'created': '2015-01-23T07:34:04Z'
            }");

            var refund = client.ChargeService.GetRefund("chrg_test_4zgsgfb13gw8kwknmgy", "rfnd_test_4ytdj6mfxqx6lqoyg50");
            Assert.AreEqual(100, refund.Amount);
            Assert.AreEqual("thb", refund.Currency);
            Assert.AreEqual("chrg_test_4zgsgfb13gw8kwknmgy", refund.ChargeId);
            Assert.AreEqual("trxn_test_4ytdj6mmjdejo4yogx6", refund.TransactionId);
            Assert.AreEqual("rfnd_test_4ytdj6mfxqx6lqoyg50", refund.Id);
            Assert.AreEqual(new DateTime(2015, 1, 23, 7, 34, 4), refund.CreatedAt);
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
                        'location': '/charges/chrg_test_4zgsgfb13gw8kwknmgy/refunds/rfnd_test_4ytdj6mfxqx6lqoyg50',
                        'amount': 100,
                        'currency': 'thb',
                        'charge': 'chrg_test_4zgsgfb13gw8kwknmgy',
                        'transaction': 'trxn_test_4ytdj6mmjdejo4yogx6',
                        'created': '2015-01-23T07:34:04Z'
                    }
                ],
                'location': '/charges/chrg_test_4zgsgfb13gw8kwknmgy/refunds'
            }");


            var refunds = client.ChargeService.GetRefunds("chrg_test_4zgsgfb13gw8kwknmgy");
            Assert.IsNotNull(refunds);
            Assert.AreEqual(20, refunds.Limit);
            Assert.AreEqual(0, refunds.Offset);
            Assert.AreEqual(1, refunds.Collection.Count);
            Assert.AreEqual("/charges/chrg_test_4zgsgfb13gw8kwknmgy/refunds", refunds.Location);
        }
    }
}

