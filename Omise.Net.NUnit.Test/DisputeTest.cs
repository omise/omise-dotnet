using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omise.Net.NUnit.Test
{
    [TestFixture]
    public class DisputeTest : TestBase
    {
        [Test]
        public void TestGetDispute() {
            stubResponse(TestHelper.GetJson("Dispute.json"));
            var dispute = client.DisputeService.GetDispute("dspt_test_508ykcub2caopy87asd");
            Assert.IsNotNull(dispute);
            Assert.AreEqual("dspt_test_508ykcub2caopy87asd", dispute.Id);
            Assert.IsFalse(dispute.LiveMode);
            Assert.AreEqual("/disputes/dspt_test_508ykcub2caopy87asd", dispute.Location);
            Assert.AreEqual(15000, dispute.Amount);
            Assert.AreEqual("thb", dispute.Currency);
            Assert.AreEqual(DisputeStatus.Pending, dispute.Status);
            Assert.AreEqual("sample message", dispute.Message);
            Assert.AreEqual("chrg_test_508ykb30i32xtnk1gth", dispute.ChargeId);
            Assert.AreEqual(new DateTime(2015, 6, 4, 4, 47, 39), dispute.CreatedAt);
        }

        [Test]
        public void TestUpdateDispute() {
            stubResponse(TestHelper.GetJson("DisputeUpdated.json"));
            var dispute = client.DisputeService.UpdateDispute("dspt_test_508o0ag0fcucuwqjafg", "sample dispute message");
            Assert.IsNotNull(dispute);
            Assert.AreEqual("dspt_test_508o0ag0fcucuwqjafg", dispute.Id);
            Assert.IsFalse(dispute.LiveMode);
            Assert.AreEqual("/disputes/dspt_test_508o0ag0fcucuwqjafg", dispute.Location);
            Assert.AreEqual(41000, dispute.Amount);
            Assert.AreEqual("thb", dispute.Currency);
            Assert.AreEqual(DisputeStatus.Pending, dispute.Status);
            Assert.AreEqual("sample dispute message", dispute.Message);
            Assert.AreEqual("chrg_test_503jmu1xi3wkko1ziuy", dispute.ChargeId);
            Assert.AreEqual(new DateTime(2015, 6, 3, 10, 47, 59), dispute.CreatedAt);
        }

        [Test]
        public void TestGetAllDisputes()
        {
            stubResponse(TestHelper.GetJson("AllDisputes.json"));
            var result = client.DisputeService.GetAllDisputes();
            Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0), result.From);
            Assert.AreEqual(new DateTime(2015, 6, 3, 10, 48, 19), result.To);
            Assert.AreEqual(0, result.Offset);
            Assert.AreEqual(20, result.Limit);
            Assert.AreEqual(1, result.Total);
            Assert.IsNotNull(result.Collection);
            Assert.AreEqual(1, result.Collection.Count);

            var collection = (List<Dispute>)result.Collection;
            var dispute = collection[0];
            Assert.AreEqual("dspt_test_508o0ag0fcucuwqjafg", dispute.Id);
            Assert.IsFalse(dispute.LiveMode);
            Assert.AreEqual("/disputes/dspt_test_508o0ag0fcucuwqjafg", dispute.Location);
            Assert.AreEqual(41000, dispute.Amount);
            Assert.AreEqual("thb", dispute.Currency);
            Assert.AreEqual(DisputeStatus.Open, dispute.Status);
            Assert.IsNull(dispute.Message);
            Assert.AreEqual("chrg_test_503jmu1xi3wkko1ziuy", dispute.ChargeId);
            Assert.AreEqual(new DateTime(2015, 6, 3, 10, 47, 59), dispute.CreatedAt);
        }

        [Test]
        public void TestGetAllOpenDisputes() {
            stubResponse(TestHelper.GetJson("AllOpenDisputes.json"));
            var result = client.DisputeService.GetAllOpenDisputes();
            Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0), result.From);
            Assert.AreEqual(new DateTime(2015, 6, 4, 4, 27, 40), result.To);
            Assert.AreEqual(0, result.Offset);
            Assert.AreEqual(20, result.Limit);
            Assert.AreEqual(1, result.Total);
            Assert.IsNotNull(result.Collection);
            Assert.AreEqual(1, result.Collection.Count);

            var collection = (List<Dispute>)result.Collection;
            var dispute = collection[0];
            Assert.AreEqual("dspt_test_508o0ag0fcucuwqjafg", dispute.Id);
            Assert.IsFalse(dispute.LiveMode);
            Assert.AreEqual("/disputes/dspt_test_508o0ag0fcucuwqjafg", dispute.Location);
            Assert.AreEqual(41000, dispute.Amount);
            Assert.AreEqual("thb", dispute.Currency);
            Assert.AreEqual(DisputeStatus.Open, dispute.Status);
            Assert.IsNull(dispute.Message);
            Assert.AreEqual("chrg_test_503jmu1xi3wkko1ziuy", dispute.ChargeId);
            Assert.AreEqual(new DateTime(2015, 6, 3, 10, 47, 59), dispute.CreatedAt);
        }

        [Test]
        public void TestGetAllPendingDisputes() 
        {
            stubResponse(TestHelper.GetJson("AllPendingDisputes.json"));
            var result = client.DisputeService.GetAllPendingDisputes();
            Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0), result.From);
            Assert.AreEqual(new DateTime(2015, 6, 4, 4, 48, 49), result.To);
            Assert.AreEqual(0, result.Offset);
            Assert.AreEqual(20, result.Limit);
            Assert.AreEqual(1, result.Total);
            Assert.IsNotNull(result.Collection);
            Assert.AreEqual(1, result.Collection.Count);

            var collection = (List<Dispute>)result.Collection;
            var dispute = collection[0];
            Assert.AreEqual("dspt_test_508ykcub2caopy87asd", dispute.Id);
            Assert.IsFalse(dispute.LiveMode);
            Assert.AreEqual("/disputes/dspt_test_508ykcub2caopy87asd", dispute.Location);
            Assert.AreEqual(15000, dispute.Amount);
            Assert.AreEqual("thb", dispute.Currency);
            Assert.AreEqual(DisputeStatus.Pending, dispute.Status);
            Assert.AreEqual("sample message", dispute.Message);
            Assert.AreEqual("chrg_test_508ykb30i32xtnk1gth", dispute.ChargeId);
            Assert.AreEqual(new DateTime(2015, 6, 4, 4, 47, 39), dispute.CreatedAt);
        }

        [Test]
        public void TestGetAllClosedDisputes() {
            stubResponse(TestHelper.GetJson("AllClosedDisputes.json"));
            var result = client.DisputeService.GetAllClosedDisputes();
            Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0), result.From);
            Assert.AreEqual(new DateTime(2015, 6, 4, 4, 40, 49), result.To);
            Assert.AreEqual(0, result.Offset);
            Assert.AreEqual(20, result.Limit);
            Assert.AreEqual(1, result.Total);
            Assert.IsNotNull(result.Collection);
            Assert.AreEqual(1, result.Collection.Count);

            var collection = (List<Dispute>)result.Collection;
            var dispute = collection[0];
            Assert.AreEqual("dspt_test_508yd4swk9lnpkakqqw", dispute.Id);
            Assert.IsFalse(dispute.LiveMode);
            Assert.AreEqual("/disputes/dspt_test_508yd4swk9lnpkakqqw", dispute.Location);
            Assert.AreEqual(10000, dispute.Amount);
            Assert.AreEqual("thb", dispute.Currency);
            Assert.AreEqual(DisputeStatus.Won, dispute.Status);
            Assert.AreEqual("test", dispute.Message);
            Assert.AreEqual("chrg_test_508ycyv41si0lvvorty", dispute.ChargeId);
            Assert.AreEqual(new DateTime(2015, 6, 4, 4, 27, 8), dispute.CreatedAt);
        }
    }
}
