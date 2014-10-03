using System;
using NUnit.Framework;

namespace Omise.Net.NUnit.Test
{
	[TestFixture]
	public class CustomerTest:TestBase
	{
		[Test]
		public void TestCreateCustomer(){
			var customerInfo = new CustomerInfo ();
			customerInfo.Email = "test2@localhost";
			customerInfo.Description = "Test customer 2";

			StubRequestWithResponse (@"{
								    'object': 'customer',
								    'id': '123',
								    'livemode': false,
								    'location': '/customers/123',
								    'default_card': null,
								    'email': 'test2@localhost',
								    'description': null,
								    'created': '2014-10-02T08:12:12Z',
								    'cards': {
								        'object': 'list',
								        'from': '1970-01-01T07:00:00+07:00',
								        'to': '2014-10-02T15:12:12+07:00',
								        'offset': 0,
								        'limit': 20,
								        'total': 0,
								        'data': [],
								        'location': '/customers/123/cards'
								    }
								}");

			var customerResult = client.CustomerService.CreateCustomer (customerInfo);
			Assert.IsNotNull (customerResult);
			Assert.AreEqual ("test2@localhost", customerResult.Email);
			Assert.IsNotNull (customerResult.Id);
		}

		[Test]
		public void TestUpdateCustomer(){
			var customerUpdateInfo = new CustomerInfo ();
			customerUpdateInfo.Email = "test11@localhost";
			customerUpdateInfo.Description = "Test Customer 11 change email";
			StubRequestWithResponse (@"{
								    'object': 'customer',
								    'id': '123',
								    'livemode': false,
								    'location': '/customers/123',
								    'default_card': null,
								    'email': 'test11@localhost',
								    'description': 'Test Customer 11 change email',
								    'created': '2014-10-02T08:12:12Z',
								    'cards': {
								        'object': 'list',
								        'from': '1970-01-01T07:00:00+07:00',
								        'to': '2014-10-02T15:31:35+07:00',
								        'offset': 0,
								        'limit': 20,
								        'total': 0,
								        'data': [],
								        'location': '/customers/123/cards'
								    }
								}");
			var customerUpdateResult = client.CustomerService.UpdateCustomer ("123", customerUpdateInfo);
			Assert.AreEqual ("test11@localhost", customerUpdateResult.Email);
			Assert.AreEqual ("Test Customer 11 change email", customerUpdateResult.Description);
		}

		[Test]
		public void TestDeleteCustomer(){
			client.CustomerService.DeleteCustomer ("123");
			StubExceptionThrow (new ApiException ());
			Assert.Throws<ApiException> (delegate {
				client.CustomerService.GetCustomer ("123");
			});
		}

		[Test]
		public void TestGetCustomerInfo(){
			StubRequestWithResponse (@"{
								    'object': 'customer',
								    'id': '123',
								    'livemode': false,
								    'location': '/customers/123',
								    'default_card': null,
								    'email': 'test2@localhost',
								    'description': 'Test customer 1',
								    'created': '2014-10-02T08:12:12Z',
								    'cards': {
								        'object': 'list',
								        'from': '1970-01-01T07:00:00+07:00',
								        'to': '2014-10-02T15:28:20+07:00',
								        'offset': 0,
								        'limit': 20,
								        'total': 0,
								        'data': [],
								        'location': '/customers/123/cards'
								    }
								}");
			var customerShowResult = client.CustomerService.GetCustomer ("123");
			Assert.IsNotNull (customerShowResult);
			Assert.AreEqual ("test2@localhost", customerShowResult.Email);
			Assert.AreEqual ("Test customer 1", customerShowResult.Description);
		}
	}
}

