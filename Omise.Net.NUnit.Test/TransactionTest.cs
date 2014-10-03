using System;
using NUnit.Framework;

namespace Omise.Net.NUnit.Test
{
	[TestFixture]
	public class TransactionTest: TestBase
	{
		[Test]
		public void TestGetAllTransactions(){
			StubRequestWithResponse (@"{
									    'object': 'list',
									    'from': '1970-01-01T07:00:00+07:00',
									    'to': '2014-10-02T17:27:36+07:00',
									    'offset': 0,
									    'limit': 20,
									    'total': 2,
									    'data': [
									        {
									            'object': 'transaction',
									            'id': '123',
									            'type': 'credit',
									            'amount': 9635,
									            'currency': 'THB',
									            'created': '2014-10-02T10:27:00Z'
									        },
									        {
									            'object': 'transaction',
									            'id': '234',
									            'type': 'credit',
									            'amount': 9635,
									            'currency': 'THB',
									            'created': '2014-10-02T10:27:31Z'
									        }
									    ]
									}");

			var transactions = client.TransactionService.GetAllTransactions (null, null, 0, 20);
			Assert.IsNotNull (transactions);
			Assert.AreEqual(20, transactions.Limit);
			Assert.AreEqual(0, transactions.Offset);
			Assert.AreEqual(2, transactions.Collection.Count);
		}

		[Test]
		public void TestGetTransaction(){
			StubRequestWithResponse(@"{
								    'object': 'transaction',
								    'id': '123',
								    'type': 'credit',
								    'amount': 9635,
								    'currency': 'THB',
								    'created': '2014-10-02T10:27:00Z'
									}");

			var transaction = client.TransactionService.GetTransaction ("123");
			Assert.IsNotNull (transaction);
			Assert.IsNotNull (transaction.Currency);
			Assert.IsNotNullOrEmpty (transaction.Type);
			Assert.GreaterOrEqual (transaction.Amount, 0);
		}
	}
}

