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
        public void TestCreateTransferWithFullAmount()
        {
            stubResponse(@"{
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
            Assert.Throws<ArgumentException>(delegate
                {
                    client.TransferService.CreateTransfer(0);
                });
        }

        [Test]
        public void TestCreateTransferWithAmount()
        {
            stubResponse(@"{
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

        [Test]
        public void TestGetAllTransfers()
        {
            stubResponse(@"{
                                        'object': 'list',
                                        'from': '1970-01-01T07:00:00+07:00',
                                        'to': '2014-10-29T11:15:32+07:00',
                                        'offset': 0,
                                        'limit': 20,
                                        'total': 1,
                                        'data': [
                                            {
                                                'object': 'transfer',
                                                'id': 'trsf_test_4xuy4dcguo06a1vncmc',
                                                'amount': 100025,
                                                'currency': 'thb',
                                                'created': '2014-10-27T07:02:54Z'
                                            }
                                        ]
                                    }");

            var transfers = client.TransferService.GetAllTransfers();
            Assert.IsNotNull(transfers);
            Assert.AreEqual(20, transfers.Limit);
            Assert.AreEqual(0, transfers.Offset);
            Assert.AreEqual(1, transfers.Total);
            Assert.AreEqual(1, transfers.Collection.Count);
        }

        [Test]
        public void TestGetAllTransfersWithPagination()
        {
            stubResponse(@"{
                                        'object': 'list',
                                        'from': '1970-01-01T07:00:00+07:00',
                                        'to': '2014-10-29T11:15:32+07:00',
                                        'offset': 0,
                                        'limit': 20,
                                        'total': 1,
                                        'data': [
                                            {
                                                'object': 'transfer',
                                                'id': 'trsf_test_4xuy4dcguo06a1vncmc',
                                                'amount': 100025,
                                                'currency': 'thb',
                                                'created': '2014-10-27T07:02:54Z'
                                            }
                                        ]
                                    }");

            var transfers = client.TransferService.GetAllTransfers(null, null, 0, 20);
            Assert.IsNotNull(transfers);
            Assert.AreEqual(20, transfers.Limit);
            Assert.AreEqual(0, transfers.Offset);
            Assert.AreEqual(1, transfers.Total);
            Assert.AreEqual(1, transfers.Collection.Count);
        }

        [Test]
        public void TestUpdateTransfer()
        {
            stubResponse(@"{
                            'object': 'transfer',
                            'id': 'trsf_test_4xs5px8c36dsanuwztf',
                            'amount': 50000,
                            'currency': 'THB',
                            'created': '2014-10-20T03:55:08Z'
                           }");

            var result = client.TransferService.UpdateTransfer("trsf_test_4xs5px8c36dsanuwztf", 50000);
            Assert.IsNotNull(result);
            Assert.AreEqual("trsf_test_4xs5px8c36dsanuwztf", result.Id);
            Assert.AreEqual(50000, result.Amount);
            Assert.AreEqual("THB", result.Currency);
            Assert.AreEqual(new DateTime(2014, 10, 20, 3, 55, 8), result.CreatedAt);
        }

        [Test]
        public void TestUpdateTransferWithInvalidAmount()
        {
            Assert.Throws<ArgumentException>(delegate
                {
                    client.TransferService.UpdateTransfer("trsf_test_4xs5px8c36dsanuwztf", -5);
                });
        }

        [Test]
        public void TestDeleteTransfer()
        {
            stubResponse(@"{
                        'object': 'transfer',
                        'id': 'trsf_test_4xs5px8c36dsanuwztf',
                        'livemode': false,
                        'deleted': true
                        }");

            var result = client.TransferService.DeleteTransfer("trsf_test_4xs5px8c36dsanuwztf");
            Assert.AreEqual("trsf_test_4xs5px8c36dsanuwztf", result.Id);
            Assert.IsTrue(result.Deleted);
        }

        [Test]
        public void TestGetTransfer()
        {
            stubResponse(@"{
                            'object': 'transfer',
                            'id': 'trsf_test_4xs5px8c36dsanuwztf',
                            'amount': 50000,
                            'currency': 'THB',
                            'created': '2014-10-20T03:55:08Z'
                           }");

            var result = client.TransferService.GetTransfer("trsf_test_4xs5px8c36dsanuwztf");
            Assert.IsNotNull(result);
            Assert.AreEqual("trsf_test_4xs5px8c36dsanuwztf", result.Id);
            Assert.AreEqual(50000, result.Amount);
            Assert.AreEqual("THB", result.Currency);
            Assert.AreEqual(new DateTime(2014, 10, 20, 3, 55, 8), result.CreatedAt);
        }
    }
}
