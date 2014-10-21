using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omise.Net.NUnit.Test
{
    [TestFixture]
    public class TransferTest: TestBase
    {
        [Test]
        public void TestCreateTransferWithFullAmount() {
            StubRequestWithResponse(@"{
                                        'object': 'transfer',
                                        'id': 'trsf_test_4xs5px8c36dsanuwztf',
                                        'amount': 50000,
                                        'currency': 'THB',
                                        'created': '2014-10-20T03:55:08Z'
                                    }");
            var result = client.TransferService.CreateTransfer();
            Assert.AreEqual(50000, result.Amount);
            Assert.AreEqual("THB", result.Currency);
        }

        [Test]
        public void TestCreateTransferWithInvalidAmount()
        {
            Assert.Throws<ArgumentException>(delegate { client.TransferService.CreateTransfer(0); });
        }

        [Test]
        public void TestCreateTransferWithAmount() 
        {
            StubRequestWithResponse(@"{
                                        'object': 'transfer',
                                        'id': 'trsf_test_4xs5px8c36dsanuwztf',
                                        'amount': 10000,
                                        'currency': 'THB',
                                        'created': '2014-10-20T03:55:08Z'
                                    }");
            var result = client.TransferService.CreateTransfer(10000);
            Assert.AreEqual(10000, result.Amount);
            Assert.AreEqual("THB", result.Currency);
        }
    }
}
